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
        InstantiateIt(transform.position, transform.rotation);
    }

    [ContextMenu("InstantiatePrefabAtMyPositionWithRandomRotation")]
    public void InstantiatePrefabAtMyPositionWithRandomRotation()
    {
        InstantiateIt(transform.position, Random.rotation);
    }

    private void InstantiateIt(Vector3 position, Quaternion rotation)
    {
        if (childOfDesiredParent != null)
        {
            Instantiate(prefab, position, rotation, childOfDesiredParent.parent);
        }
        else
        {
            // set my parent as its parent
            Instantiate(prefab, position, rotation, transform.parent);
        }
    }
}
