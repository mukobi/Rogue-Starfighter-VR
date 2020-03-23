using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMaterialProperties : MonoBehaviour
{
    [SerializeField] private Material target = default;
    [SerializeField] private Material source = default;

    public void CopyProperties()
    {
        target.CopyPropertiesFromMaterial(source);
    }
}
