/* CrossfadeAudiosource Attribution
 * 
 * This script for crossfading clips on an audiosource was copied from u/danokablamo
 * on Reddit. See the following link for the original post:
 * https://www.reddit.com/r/Unity3D/comments/bjvp1w/heres_a_script_that_lets_you_crossfade_not_fade/
 * 
 * Modifications: cached the attached AudioSource because I'm anal.
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossfadeAudiosource : MonoBehaviour
{
    private AudioSource attachedAudioSource;

    private void Start()
    {
        attachedAudioSource = GetComponent<AudioSource>();
    }

    public void Fade(AudioClip clip, float volume)
    {
        StartCoroutine(FadeIt(clip, volume));
    }

    IEnumerator FadeIt(AudioClip clip, float volume)
    {

        ///Add new audiosource and set it to all parameters of original audiosource
        AudioSource fadeOutSource = gameObject.AddComponent<AudioSource>();
        fadeOutSource.clip = attachedAudioSource.clip;
        fadeOutSource.time = attachedAudioSource.time;
        fadeOutSource.volume = attachedAudioSource.volume;
        fadeOutSource.outputAudioMixerGroup = attachedAudioSource.outputAudioMixerGroup;

        //make it start playing
        fadeOutSource.Play();

        //set original audiosource volume and clip
        attachedAudioSource.volume = 0f;
        attachedAudioSource.clip = clip;
        float t = 0;
        float v = fadeOutSource.volume;
        attachedAudioSource.Play();

        //begin fading in original audiosource with new clip as we fade out new audiosource with old clip
        while (t < 0.98f)
        {
            t = Mathf.Lerp(t, 1f, Time.deltaTime * 0.2f);
            fadeOutSource.volume = Mathf.Lerp(v, 0f, t);
            attachedAudioSource.volume = Mathf.Lerp(0f, volume, t);
            yield return null;
        }
        attachedAudioSource.volume = volume;
        //destroy the fading audiosource
        Destroy(fadeOutSource);
        yield break;
    }
}