using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(CrossfadeAudiosource))]
public class MusicManager : MonoBehaviour
{
    [System.Serializable]
    public struct NamedAudioClip
    {
        public string name;
        public AudioClip clip;
    }

    [SerializeField] private List<NamedAudioClip> clips = new List<NamedAudioClip>();

    private CrossfadeAudiosource crossfadeAudiosource;

    private void Start()
    {
        crossfadeAudiosource = GetComponent<CrossfadeAudiosource>();
    }

    public void PlayClip(string clipName, float volume = 1)
    {
        // assumes there is a clip in `clips` with `name` == `clipName`
        AudioClip clip = clips.Single(n => n.name == clipName).clip;
        crossfadeAudiosource.Fade(clip, volume);
    }
}
