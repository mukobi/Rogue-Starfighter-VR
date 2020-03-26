using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine.VFX;

public class HyperspaceFXCoordinator : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private VisualEffect hyperspaceJumpVfx = default;
    [SerializeField] private VisualEffect hyperspaceExitVfx = default;
    [SerializeField] private GameObject HyperSpaceTunnel = default;

    [SerializeField] private AudioCuePlayer jumpXWAudioCue = default;
    [SerializeField] private AudioCuePlayer exitXWAudioCue = default;

    [Header("Config")]
    //[SerializeField] private float jumpFlashDurationSeconds = default;
    //[SerializeField] private float jumpFadeDurationSeconds = default;
    [SerializeField] private float tunnelActiveDuration = default;
    [SerializeField] private float intervalBetweenExitStartAndTunnelDissapearSeconds = default;

    private void Start()
    {
        // disable graphs at start for performance
        // (For some stupid reason, they eat up about 10ms when not playing but the component is still enabled)
        hyperspaceJumpVfx.enabled = false;
        hyperspaceExitVfx.enabled = false;
    }

    [ContextMenu("Jump to Hyperspace VFX")]
    public async Task JumpToHyperspace()
    {
        hyperspaceJumpVfx.enabled = true;

        jumpXWAudioCue.PlayOnExistingAudioSource();

        float lifetime = hyperspaceJumpVfx.GetFloat("lifetime");
        hyperspaceJumpVfx.Play();
        await Task.Delay((int)(lifetime * 1000));
        HyperSpaceTunnel.SetActive(true); // TODO: add optional bool param or different function to not set tunnel active

        await Task.Delay(4000);
        hyperspaceJumpVfx.enabled = false;
    }
    
    [ContextMenu("Exit Hyperspace VFX")]
    public async Task ExitHyperspace()
    {
        hyperspaceExitVfx.enabled = true;

        exitXWAudioCue.PlayOnExistingAudioSource();

        hyperspaceExitVfx.Play();

        await Task.Delay((int)(intervalBetweenExitStartAndTunnelDissapearSeconds * 1000));

        HyperSpaceTunnel.SetActive(false);

        await Task.Delay(4000);
        hyperspaceExitVfx.enabled = false;
    }

    [ContextMenu("Full Jump and Exit")]
    public async Task FullJump()
    {
        // make the jump, putting us into the tunnel
        await JumpToHyperspace();

        // wait in the tunnel
        await TunnelDelay();

        // exit the jump, taking us out of the tunnel
        await ExitHyperspace();
    }

    public async Task TunnelDelay()
    {
        await Task.Delay((int)(tunnelActiveDuration * 1000));
    }
}
