using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFlashToggler : MonoBehaviour
{
    private Material material;

    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    public void SetFlashing(bool toFlash)
    {
        material.SetFloat("__enable_flashing", toFlash ? 1.0f : 0.0f);
    }

    public void SetConstantEmission(bool toEmit)
    {
        material.SetFloat("__force_emission_on", toEmit ? 1.0f : 0.0f);
    }
}
