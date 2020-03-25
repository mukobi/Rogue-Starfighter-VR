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

    [Header("Jump config")]
    [SerializeField] private float jumpFlashDurationSeconds = default;
    [SerializeField] private float jumpFadeDurationSeconds = default;
    [SerializeField] private float tunnelActiveDuration = default;

    [ContextMenu("Jump to Hyperspace VFX")]
    public async Task JumpToHyperspace()
    {
        float lifetime = hyperspaceJumpVfx.GetFloat("lifetime");

        hyperspaceJumpVfx.Play();
        await Task.Delay((int)(lifetime * 1000));
        HyperSpaceTunnel.SetActive(true);
        Task VRFadeTask = VRFadeController.FlashThenFadeTransparent(Color.white, jumpFlashDurationSeconds, jumpFadeDurationSeconds);
        await VRFadeTask;
    }
    
    [ContextMenu("Exit Hyperspace VFX")]
    public async Task ExitHyperspace()
    {
        Task VRFadeTask = VRFadeController.FadeThenFlashTransparent(Color.white, jumpFadeDurationSeconds, jumpFlashDurationSeconds);

        await Task.Delay((int)(jumpFadeDurationSeconds * 1000));

        HyperSpaceTunnel.SetActive(false);

        float lifetime = hyperspaceJumpVfx.GetFloat("lifetime");

        //hyperspaceExitVfx.Play();

        await Task.Delay((int)(lifetime * 1000));

        await VRFadeTask;
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
