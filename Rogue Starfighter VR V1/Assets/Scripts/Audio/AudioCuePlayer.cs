using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCuePlayer : MonoBehaviour
{
    [SerializeField] private AudioCueScriptableObject audioCue = default;
    [SerializeField] private bool playOnAwake = false;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (playOnAwake)
        {
            if (audioSource != null)
            {
                PlayOnExistingAudioSource();
            }
            else
            {
                PlayAtMyPosition();
            }
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

    public void PlayOnPassedInAudioSource(AudioSource passedInAudioSource)
    {
        audioCue.PlayOnExistingAudioSourceAtPosition(passedInAudioSource);
    }

    public void PlayOnExistingAudioSource()
    {
        audioCue.PlayOnExistingAudioSourceAtPosition(audioSource);
    }

    public void PlayOneShotOnExistingAudioSource()
    {
        audioCue.PlayOneShotOnExistingAudioSourceAtPosition(audioSource);
    }
}
