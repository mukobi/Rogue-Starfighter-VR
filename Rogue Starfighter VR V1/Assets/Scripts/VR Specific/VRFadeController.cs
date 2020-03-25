using UnityEngine;
using System.Collections;
using Valve.VR;
using System.Threading.Tasks;


public class VRFadeController
{
    public static async Task FlashThenFadeTransparent(Color toColor, float flashDurationSeconds, float fadeDurationSeconds)
    {
        // instantly flash on the desired colour
        SteamVR_Fade.View(toColor, 0);
        //SteamVR_Fade.View(toColor, flashDurationSeconds);

        await Task.Delay((int)(flashDurationSeconds*1000));

        // fade back out over time
        SteamVR_Fade.View(toColor, 0);
        SteamVR_Fade.View(Color.clear, fadeDurationSeconds);
    }

    public static async Task FadeInFadeOut(Color toColor, float fadeInDurationSeconds, float fadeOutDurationSeconds)
    {
        // instantly flash on the desired colour
        SteamVR_Fade.View(Color.clear, 0);
        SteamVR_Fade.View(toColor, fadeInDurationSeconds);
        //SteamVR_Fade.View(toColor, flashDurationSeconds);

        await Task.Delay((int)(fadeInDurationSeconds * 1000));

        // fade back out over time
        SteamVR_Fade.View(toColor, 0);
        SteamVR_Fade.View(Color.clear, fadeOutDurationSeconds);
    }
}
