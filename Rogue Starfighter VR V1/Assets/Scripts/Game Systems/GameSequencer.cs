using UnityEngine;
using UnityEngine.XR;
using System.Threading;
using System.Threading.Tasks;

public class GameSequencer : MonoBehaviour
{
    [Header("System Dependencies")]
    public ButtonGameController buttonGameController;
    public MasterSystemController masterSystemController;
    public HyperdriveSwitchController hyperdriveSwitchController;
    public MusicManager musicManager;

    [Header("Entity Dependencies")]
    public GameObject StarDestroyer;

    [Header("VFX")]
    public HyperspaceFXCoordinator hyperspaceFXCoordinator;

    [Header("SFX")]
    public AudioSource GlobalSFX;
    public AudioCuePlayer HyperspaceExitCue;


    [Header("Config")]
    [Range(1, 2)] [SerializeField] private float supersamplingRatio = 1;

    private CancellationTokenSource cts;

    async void Start()
    {
        await MainGameTask();
    }

    private async Task MainGameTask()
    {
        /*** Initialization ***/
        Debug.Log("Start: Initialization.");
        EnableSupersampling();

        StarDestroyer.SetActive(false);
        Debug.Log("End: Initialization.");


        /*** Main Game Sequence ***/
        Debug.Log("Start: Main game sequence");

        await Task.Delay(5000);

        /* Make jump to hyperspace */
        await HyperspaceSequence1();

        /* Emerge in new location with rebel ship */
        await Task.Delay(5000);

        // TODO: use linked token stuff
        cts = new CancellationTokenSource();
        CancellationToken ct = cts.Token;
        await RequireButtonGameRandomButtonsPressed(ct);

        await Task.Delay(3000);

        /* Enter Star Destroyer sequence */
        await EnterStarDestroyerSequence();


        await Task.Delay(80000);

        await HyperspaceSequence2();

        Debug.Log("End: Main game sequence");
    }


    private async Task RequireButtonGameRandomButtonsPressed(CancellationToken ct)
    {
        masterSystemController.CanDisableASystem = false;
        await buttonGameController.RequireRandomNumberOfButtonsPressed(ct);
        masterSystemController.CanDisableASystem = true;
    }

    private async Task HyperspaceSequence1()
    {
        cts = new CancellationTokenSource();
        CancellationToken ct = cts.Token;

        await RequireButtonGameRandomButtonsPressed(ct);
        await hyperdriveSwitchController.RequireSwitchThrown(ct);
        hyperdriveSwitchController.LockSwitchInForwardPosition();
        musicManager.VolumeFader.LinearFade(0, 2);
        await hyperspaceFXCoordinator.FullJump();
        musicManager.VolumeFader.LinearFade(1, 2);
        hyperdriveSwitchController.LockSwitchInInitialPosition();
    }

    private async Task EnterStarDestroyerSequence()
    {
        musicManager.PlayClip("The Asteroid Field");
        await Task.Delay(2500);
        HyperspaceExitCue.PlayOnPassedInAudioSource(GlobalSFX);
        await Task.Delay(1850);
        StarDestroyer.SetActive(true);
    }

    private async Task HyperspaceSequence2()
    {
        // TODO: use linked token stuff
        cts = new CancellationTokenSource();
        CancellationToken ct = cts.Token;

        await RequireButtonGameRandomButtonsPressed(ct);
        await hyperdriveSwitchController.RequireSwitchThrown(ct);
        hyperdriveSwitchController.LockSwitchInForwardPosition();
        Task jumpTask = hyperspaceFXCoordinator.JumpToHyperspace();

        await Task.Delay(2000);
        StarDestroyer.SetActive(false);

        await jumpTask;
        hyperdriveSwitchController.LockSwitchInInitialPosition();
    }

    private void EnableSupersampling()
    {
        XRSettings.eyeTextureResolutionScale = supersamplingRatio;
    }
}
