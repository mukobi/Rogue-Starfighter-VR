using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFlashToggler : MonoBehaviour
{
    private Material material;
    [SerializeField] private int materialIndex = 0;

    private void Awake()
    {
        material = GetComponent<MeshRenderer>().materials[materialIndex];
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
