using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCuePlayer : MonoBehaviour
{
    [SerializeField] private AudioCueScriptableObject audioCue = default;
    [SerializeField] private bool playOnAwake = false;

    private void Awake()
    {
        if(playOnAwake)
        {
            PlayAtMyPosition();
        }
    }

    public void PlayAtMyPosition()
    {
        audioCue.PlayWithNewAudioSourceAtPosition(transform.position);
    }

    public void PlayAtSpecificPosition(Vector3 position)
    {
        audioCue.PlayWithNewAudioSourceAtPosition(position);
    }

    public void PlayOnExistingAudioSource(AudioSource audioSource)
    {
        audioCue.PlayOnExistingAudioSourceAtPosition(audioSource);
    }
}
