﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioCue", menuName = "ScriptableObjects/AudioCueScriptableObject", order = 1)]
public class AudioCueScriptableObject : ScriptableObject
{
    public AudioClip[] clips;
    public AudioMixerGroup audioMixerGroup;
    [Range(0, 1)] public float minVolume;
    [Range(0, 1)] public float maxVolume;
    public float spatialBlend = 1.0f;
    public float minPitch;
    public float maxPitch;
    public float maxDistance = 500;
    public AudioRolloffMode rolloffMode = AudioRolloffMode.Logarithmic;

    public GameObject PlayWithNewAudioSourceAtPosition(Vector3 position)
    {
        // choose random variables
        AudioClip clip = clips[Random.Range(0, clips.Length)];
        float volume = Random.Range(minVolume, maxVolume);
        float pitch = Random.Range(minPitch, maxPitch);

        // play that thang
        GameObject obj = new GameObject
        {
            name = "Audio Source"
        }; // create a new GameObject to play from
        obj.transform.position = position;
        AudioSource audioSource = obj.AddComponent<AudioSource>();
        audioSource.pitch = pitch;
        audioSource.spatialBlend = spatialBlend;
        audioSource.outputAudioMixerGroup = audioMixerGroup;
        audioSource.maxDistance = maxDistance;
        audioSource.rolloffMode = rolloffMode;
        audioSource.spatialize = false;
        audioSource.PlayOneShot(clip, volume);

        Destroy(obj, clip.length / pitch); // clean up created object after done playing
        return obj;
    }

    public void PlayOnExistingAudioSourceAtPosition(AudioSource audioSource)
    {
        // choose random variables
        AudioClip clip = clips[Random.Range(0, clips.Length)];
        float volume = Random.Range(minVolume, maxVolume);
        float pitch = Random.Range(minPitch, maxPitch);

        // play that thang
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(clip, volume);
    }
}
