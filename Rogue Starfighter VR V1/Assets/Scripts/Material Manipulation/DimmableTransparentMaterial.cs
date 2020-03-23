using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimmableTransparentMaterial : DimmableAbstract
{
    [SerializeField] private Material material = default;
    [SerializeField] private string opacityMaterialID = default;
    public override float DimmableValue01 { set => material.SetFloat(opacityMaterialID, value); }
}
