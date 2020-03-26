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
    public TextWriteOn holoHUDWriteOn;

    [Header("Entity Dependencies")]
    public Transform MoveOppositePlayerPosition;
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
        /* graphics */
        EnableSupersampling();

        /* initialize entities */
        StarDestroyer.SetActive(false);
        Debug.Log("End: Initialization.");


        /*** Main Game Sequence ***/
        Debug.Log("Start: Main game sequence");

        await Task.Delay(15000);

        /* Make jump to hyperspace */
        await HyperspaceSequence1();

        /* Emerge in new location with rebel ship */
        await Task.Delay(5000);

        /** Tutorial **/

        /* Tutorial initialization */
        masterSystemController.CanDisableASystem = true;

        // TODO: use linked token stuff
        cts = new CancellationTokenSource();
        CancellationToken ct = cts.Token;
        await RequireButtonGameRandomButtonsPressed(ct);

        await Task.Delay(3000);

        /* Enter Star Destroyer sequence */
        await EnterStarDestroyerSequence();

        /* Fight Imperials sequence */
        await Task.Delay(80000);

        /* Exit into hyperspace sequence */
        await HyperspaceSequence2();

        /* Credits */
        holoHUDWriteOn.WriteOnText("Thank you for playing!");

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

        holoHUDWriteOn.WriteOnText("Make the calculations with the buttons then throw the hyperdrive switch to make the jump");
        await RequireButtonGameRandomButtonsPressed(ct);
        await hyperdriveSwitchController.RequireSwitchThrown(ct);
        holoHUDWriteOn.WriteOffText();
        hyperdriveSwitchController.LockSwitchInForwardPosition();
        musicManager.VolumeFader.LinearFade(0, 2);
        await hyperspaceFXCoordinator.FullJump();
        musicManager.VolumeFader.LinearFade(1, 2);
        hyperdriveSwitchController.LockSwitchInInitialPosition();
    }

    private async Task EnterStarDestroyerSequence()
    {
        holoHUDWriteOn.WriteOnText("Warning: Detecting a large object emerging from hyperspace!");
        musicManager.PlayClip("The Asteroid Field");
        await Task.Delay(2500);
        HyperspaceExitCue.PlayOnPassedInAudioSource(GlobalSFX);
        holoHUDWriteOn.WriteOffText();
        await Task.Delay(1850);
        MoveOppositePlayerPosition.position = Vector3.zero; // reset position so ISD spawns in front of player
        StarDestroyer.SetActive(true);
    }

    private async Task HyperspaceSequence2()
    {
        // TODO: use linked token stuff
        cts = new CancellationTokenSource();
        CancellationToken ct = cts.Token;

        holoHUDWriteOn.WriteOnText("Make the calculations with the buttons then throw the hyperdrive switch to make the jump");
        masterSystemController.CanDisableASystem = false;
        await RequireButtonGameRandomButtonsPressed(ct);
        await hyperdriveSwitchController.RequireSwitchThrown(ct);
        holoHUDWriteOn.WriteOffText();
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
