using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine.VFX;

public class HyperspaceVFXCoordinator : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private VisualEffect hyperspaceJumpVfx = default;
    [SerializeField] private VisualEffect hyperspaceExitVfx = default;
    [SerializeField] private GameObject HyperSpaceTunnel = default;

    [Header("Config")]
    //[SerializeField] private float jumpFlashDurationSeconds = default;
    //[SerializeField] private float jumpFadeDurationSeconds = default;
    [SerializeField] private float tunnelActiveDuration = default;
    [SerializeField] private float intervalBetweenExitStartAndTunnelDissapearSeconds = default;

    [ContextMenu("Jump to Hyperspace VFX")]
    public async Task JumpToHyperspace()
    {
        float lifetime = hyperspaceJumpVfx.GetFloat("lifetime");

        hyperspaceJumpVfx.Play();
        await Task.Delay((int)(lifetime * 1000));
        HyperSpaceTunnel.SetActive(true); // TODO: add optional bool param to not set tunnel active
        //Task VRFadeTask = VRFadeController.FlashThenFadeTransparent(Color.white, jumpFlashDurationSeconds, jumpFadeDurationSeconds);
        //await VRFadeTask;
    }
    
    [ContextMenu("Exit Hyperspace VFX")]
    public async Task ExitHyperspace()
    {
        hyperspaceExitVfx.Play();

        //Task VRFadeTask = VRFadeController.FadeThenFlashTransparent(Color.white, jumpFadeDurationSeconds, jumpFlashDurationSeconds);

        await Task.Delay((int)(intervalBetweenExitStartAndTunnelDissapearSeconds * 1000));

        HyperSpaceTunnel.SetActive(false);

        //await VRFadeTask;
    }

    [ContextMenu("Full Jump and Exit")]
    public async Task FullJump()
    {
        // make the jump, putting us into the tunnel
        await JumpToHyperspace();

        // wait in the tunnel
        await Task.Delay((int)(tunnelActiveDuration * 1000));

        // exit the jump, taking us out of the tunnel
        await ExitHyperspace();
    }
}
