using UnityEngine;
using UnityEngine.XR;
using System.Threading.Tasks;

public class GameSequencer : MonoBehaviour
{
    [Header("Config")]
    [Range(1, 2)] [SerializeField] private float supersamplingRatio = 1;

    [Header("SFX")]
    public AudioSource GlobalSFX;
    public AudioCuePlayer HyperspaceExitCue;

    async void Start()
    {
        await MainGameTask();
    }

    private async Task MainGameTask()
    {
        /*** Initialization ***/
        Debug.Log("Start: Initialization.");
        EnableSupersampling();
        Debug.Log("End: Initialization.");


        /*** Main Game Sequence ***/
        Debug.Log("Start: Main game sequence");

        /* Load Star Destroyer */
        await Task.Delay(2500);
        HyperspaceExitCue.PlayOnPassedInAudioSource(GlobalSFX);
        await Task.Delay(1850); // 3 sec from start of hspace exit to boom
        await GameSceneManager.AddSceneIfNotLoaded(1); // scene with Star Destroyer

        Debug.Log("End: Main game sequence");
    }

    private void EnableSupersampling()
    {
        XRSettings.eyeTextureResolutionScale = supersamplingRatio;
    }
}
