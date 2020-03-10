using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCuePlayer : MonoBehaviour
{
    [SerializeField] private AudioCueScriptableObject audioCue = default;

    public void PlayAtMyPosition()
    {
        audioCue.PlayWithNewAudioSourceAtPosition(transform.position);
    }

    public void PlayAtSpecificPosition(Vector3 position)
    {
        audioCue.PlayWithNewAudioSourceAtPosition(position);
    }
}
