using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine.VFX;

public class HyperspaceVFXCoordinator : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private VisualEffect hyperspaceJumpVfx = default;
    //[SerializeField] private VisualEffect hyperspaceExitVfx = default;

    [Header("Jump config")]
    [SerializeField] private float jumpFlashDurationSeconds = default;
    [SerializeField] private float jumpFadeDurationSeconds = default;

    [ContextMenu("Jump to Hyperspace VFX")]
    public async Task JumpToHyperspace()
    {
        float lifetime = hyperspaceJumpVfx.GetFloat("lifetime");

        hyperspaceJumpVfx.Play();
        await Task.Delay((int)(lifetime * 1000));
        Task VRFadeTask = VRFadeController.FlashThenFadeTransparent(Color.white, jumpFlashDurationSeconds, jumpFadeDurationSeconds);
        // TODO: enable hyperspace tunnel
        await VRFadeTask;
    }
}
