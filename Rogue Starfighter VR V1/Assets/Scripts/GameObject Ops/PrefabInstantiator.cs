using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabInstantiator : MonoBehaviour
{
    public GameObject prefab;

    [Tooltip("Optional, leave null to instantiate under my parent.")]
    public Transform childOfDesiredParent;

    [ContextMenu("InstantiatePrefabAtMyTransform")]
    public void InstantiatePrefabAtMyTransform()
    {
        if (childOfDesiredParent != null)
        {
            Instantiate(prefab, transform.position, transform.rotation, childOfDesiredParent.parent);
        }
        else
        {
            // set my parent as its parent
            Instantiate(prefab, transform.position, transform.rotation, transform.parent);
        }
    }
}
