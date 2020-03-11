using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGreenRingToggler : MonoBehaviour
{
    private Material material;

    private const float offIntensity = 0.0f;
    private const float onIntensity = 100.0f;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().materials[1];
    }

    public void ToggleConstantEmission(bool toEmit)
    {
        material.SetFloat("_UseEmissiveIntensity", toEmit ? 1 : 0);
        material.SetFloat("_EmissiveIntensity", toEmit ? onIntensity : offIntensity);
    }
}
