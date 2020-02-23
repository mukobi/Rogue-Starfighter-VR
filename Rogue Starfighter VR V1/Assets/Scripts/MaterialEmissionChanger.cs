using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialEmissionChanger : MonoBehaviour
{
    [ColorUsage(true, true)]
    public Color offColor;
    [ColorUsage(true, true)]
    public Color onColor;


    Material material;

    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    public void SetEmission(bool emissionOn)
    {
        material.SetColor("_EmissionColor", emissionOn ? onColor : offColor);
    }
}
