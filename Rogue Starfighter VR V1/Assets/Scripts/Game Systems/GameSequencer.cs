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
    public ForwardEngine playerEngine;

    [Header("Entity Dependencies")]
    public MoveOppositePlayerMovement MoveOppositePlayerPositionRoot;
    public GameObject StarDestroyer;
    public GameObject CR90;
    public Transform CR90TransformTarget;

    //TODO: Don't do this. This is a hack.
    public GameObject CollidersXW;

    [Header("VFX")]
    public HyperspaceFXCoordinator hyperspaceFXCoordinator;
    public GameObject ambientSpaceParticles;

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
        CollidersXW.SetActive(true);
        StarDestroyer.SetActive(false);
        Debug.Log("End: Initialization.");


        /*** Main Game Sequence ***/
        Debug.Log("Start: Main game sequence");

        await Task.Delay(20000);

        /* Incoming transmission */
        holoHUDWriteOn.WriteOnText("Incoming transmission...");
        await Task.Delay(3000);
        holoHUDWriteOn.WriteOnText("\"Hello, this is the CR90 cruiser Kryze calling on all rebel channels.\"");
        await Task.Delay(4000);
        holoHUDWriteOn.WriteOnText("\"We have been damaged and require an escort while we make repairs.\"");
        await Task.Delay(4000);
        holoHUDWriteOn.WriteOnText("\"If you are hearing this, please send help. and may the Force be with you.\"");
        await Task.Delay(4000);

        /* Make jump to hyperspace */
        await HyperspaceSequence1();

        /* Emerge in new location with rebel ship */
        await Task.Delay(2000);

        /** Tutorial **/

        /* Tutorial proper */
        masterSystemController.CanDisableASystem = true;

        holoHUDWriteOn.WriteOnText("\"Thank you for helping, pilot! It says here you're a rookie, so why don't you review your controls.\"");
        await Task.Delay(5000);
        holoHUDWriteOn.WriteOnText("\"Grab the joystick and use it to steer. Try spinning - that's a good trick!\"");
        await Task.Delay(6000);
        holoHUDWriteOn.WriteOnText("\"Wait, something isn't right...\"");
        await Task.Delay(3000);

        /* Enter Star Destroyer sequence */
        await EnterStarDestroyerSequence();

        holoHUDWriteOn.WriteOnText("\"Looks like you'll have to learn quick! Lock s-foils in attack position and hold of the enemy!\"");
        await Task.Delay(5000);
        holoHUDWriteOn.WriteOffText();

        //holoHUDWriteOn.WriteOnText("\"\"");


        // TODO: use linked token stuff
        //await RequireButtonGameRandomButtonsPressed(ct);


        /* Fight Imperials sequence */
        await Task.Delay(60000);

        holoHUDWriteOn.WriteOnText("\"Nice work! We've fixed our hyperdrive, so let's get out of here!\"");
        CollidersXW.SetActive(false); // TODO: Not this, this is a hack to not get shot at the end.
        await Task.Delay(3000);

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

        await HyperspaceJump1();
    }

    [ContextMenu("Hyperspace Jump 1")]
    private async Task HyperspaceJump1()
    {
        playerEngine.BaseCruiseSpeed = 0;
        hyperdriveSwitchController.LockSwitchInForwardPosition();
        musicManager.VolumeFader.LinearFade(0, 2);

        await hyperspaceFXCoordinator.JumpToHyperspace();
        // in the tunnel now
        ambientSpaceParticles.SetActive(false);
        await hyperspaceFXCoordinator.TunnelDelay();
        // done with the tunnel, set up the new scene
        MoveOppositePlayerPositionRoot.RecenterIgnoreChildren();
        EnterCR90();

        await hyperspaceFXCoordinator.ExitHyperspace();
        // out of hyperspace
        ambientSpaceParticles.SetActive(true);

        playerEngine.BaseCruiseSpeed = 30;
        musicManager.VolumeFader.LinearFade(1, 2);
        hyperdriveSwitchController.LockSwitchInInitialPosition();
    }

    private void EnterCR90()
    {
        CR90.transform.position = CR90TransformTarget.position;
        CR90.transform.rotation = CR90TransformTarget.rotation;
        CR90.SetActive(true);
    }

    private async Task EnterStarDestroyerSequence()
    {
        holoHUDWriteOn.WriteOnText("Warning: Detecting a large object emerging from hyperspace!");
        //musicManager.PlayClip("The Asteroid Field"); // TODO uncomment for later version with built-in music
        await Task.Delay(2500);
        HyperspaceExitCue.PlayOnPassedInAudioSource(GlobalSFX);
        holoHUDWriteOn.WriteOffText();
        await Task.Delay(1850);
        MoveOppositePlayerPositionRoot.RecenterPreserveChildrenWorldPosition();
        StarDestroyer.transform.rotation = CR90.transform.rotation;
        StarDestroyer.transform.position = CR90.transform.position - 1500 * CR90.transform.forward;
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

        musicManager.VolumeFader.LinearFade(0, 2);
        holoHUDWriteOn.WriteOffText();
        hyperdriveSwitchController.LockSwitchInForwardPosition();

        Task jumpTask = hyperspaceFXCoordinator.JumpToHyperspace();

        await Task.Delay(2000);
        StarDestroyer.SetActive(false);

        await jumpTask;
        // in the tunnel
        ambientSpaceParticles.SetActive(false);
        hyperdriveSwitchController.LockSwitchInInitialPosition();
    }

    private void EnableSupersampling()
    {
        XRSettings.eyeTextureResolutionScale = supersamplingRatio;
    }
}
