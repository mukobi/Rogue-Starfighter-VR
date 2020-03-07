﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioCue", menuName = "ScriptableObjects/AudioCueScriptableObject", order = 1)]
public class AudioCueScriptableObject : ScriptableObject
{
    public AudioClip[] clips;
    public AudioMixerGroup audioMixerGroup;
    public float minVolume;
    public float maxVolume;
    public float minPitch;
    public float maxPitch;
    public AudioRolloffMode rolloffMode = AudioRolloffMode.Logarithmic;

    public GameObject Play(Vector3 position)
    {
        Debug.Log("Playing a one shot-sound.");

        // choose random variables
        AudioClip clip = clips[Random.Range(0, clips.Length)];
        float volume = Random.Range(minVolume, maxVolume);
        float pitch = Random.Range(minPitch, maxPitch);

        // play that thang
        GameObject obj = new GameObject(); // create a new GameObject to play from
        obj.transform.position = position;
        AudioSource audioSource = obj.AddComponent<AudioSource>();
        audioSource.pitch = pitch;
        audioSource.spatialBlend = 1.0f;
        audioSource.outputAudioMixerGroup = audioMixerGroup;
        audioSource.PlayOneShot(clip, volume);
        audioSource.rolloffMode = rolloffMode;

        Destroy(obj, clip.length / pitch); // clean up created object after done playing
        return obj;
    }
}
