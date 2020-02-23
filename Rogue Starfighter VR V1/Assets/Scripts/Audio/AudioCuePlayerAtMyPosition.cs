using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCuePlayerAtMyPosition : MonoBehaviour
{
    [SerializeField] private AudioCueScriptableObject audioCue = default;

    public void PlayAtMyPosition()
    {
        audioCue.Play(transform.position);
    }
}
