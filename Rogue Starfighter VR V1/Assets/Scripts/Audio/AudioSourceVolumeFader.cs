using UnityEngine;
using System.Collections;

public class AudioSourceVolumeFader : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void LinearFade(float newVolume, float fadeTime)
    {
        StartCoroutine(LinearFadeCoroutine(newVolume, fadeTime));
    }

    private IEnumerator LinearFadeCoroutine(float newVolume, float fadeTime)
    {
        newVolume = Mathf.Clamp01(newVolume);
        float initialVolume = audioSource.volume;
        float startTime = Time.time;
        float elapsedTime;
        while ((elapsedTime = Time.time) < startTime + fadeTime)
        {
            float volume = Mathf.Lerp(initialVolume, newVolume, elapsedTime / fadeTime);
            audioSource.volume = volume;
            yield return null;
        }
        audioSource.volume = newVolume;
    }
}
