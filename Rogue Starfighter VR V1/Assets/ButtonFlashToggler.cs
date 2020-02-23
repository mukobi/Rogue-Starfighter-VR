using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFlashToggler : MonoBehaviour
{
    private Material material;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    public void ToggleFlashing(bool toFlash)
    {
        material.SetFloat("__enable_flashing", toFlash ? 1.0f : 0.0f);
    }

    public void ToggleConstantEmission(bool toEmit)
    {
        material.SetFloat("__force_emission_on", toEmit ? 1.0f : 0.0f);
    }
}
