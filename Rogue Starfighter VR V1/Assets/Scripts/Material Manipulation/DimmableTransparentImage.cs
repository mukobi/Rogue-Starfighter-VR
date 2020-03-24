using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DimmableTransparentImage : DimmableAbstract
{
    private Material material;
    [SerializeField] private string opacityMaterialID = default;

    private void Start()
    {
        material = GetComponent<Image>().material;
    }
    public override float DimmableValue01 { set => material.SetFloat(opacityMaterialID, value); }
}
