using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public struct NamedAudioClip
{
    public string name;
    public AudioClip clip;
}

[RequireComponent(typeof(CrossfadeAudiosource))]
public class MusicManager : MonoBehaviour
{
    [SerializeField] private List<NamedAudioClip> clips = new List<NamedAudioClip>();

    public AudioSourceVolumeFader VolumeFader { get; private set; }
    private CrossfadeAudiosource crossfadeAudiosource;

    private void Start()
    {
        VolumeFader = GetComponent<AudioSourceVolumeFader>();
        crossfadeAudiosource = GetComponent<CrossfadeAudiosource>();
    }

    public void PlayClip(string clipName, float volume = 1)
    {
        // assumes there is a clip in `clips` with `name` == `clipName`
        AudioClip clip = clips.Single(n => n.name == clipName).clip;
        crossfadeAudiosource.Fade(clip, volume);
    }
}
