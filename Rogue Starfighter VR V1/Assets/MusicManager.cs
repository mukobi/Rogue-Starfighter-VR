using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public AudioMixerSnapshot fullMix;
    public AudioMixerSnapshot muteMusic;
    public AudioMixerSnapshot muteAllAudio;

    public float transitionTime = 0.66f;

    public void TransitionToFullMix()
    {
        fullMix.TransitionTo(transitionTime);
    }
    public void MuteMusic()
    {
        muteMusic.TransitionTo(transitionTime);
    }
    public void MuteAllAudio()
    {
        muteAllAudio.TransitionTo(transitionTime);
    }
}
