using UnityEngine;
using System.Threading.Tasks;

public class GameSequencer : MonoBehaviour
{
    [Header("SFX")]
    public AudioSource GlobalSFX;
    public AudioCuePlayer HyperspaceExitCue;

    async void Start()
    {
        await MainGameTask();
    }

    private async Task MainGameTask()
    {
        Debug.Log("Start main game sequence");

        /*** SECTION: Load Star Destroyer ***/
        await Task.Delay(2500);
        HyperspaceExitCue.PlayOnPassedInAudioSource(GlobalSFX);
        await Task.Delay(1850); // 3 sec from start of hspace exit to boom
        await GameSceneManager.AddSceneIfNotLoaded(1); // scene with Star Destroyer

        Debug.Log("End main game sequence");
    }
}
