using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabInstantiator : MonoBehaviour
{
    public GameObject prefab;

    [ContextMenu("InstantiatePrefabAtMyTransform")]
    public void InstantiatePrefabAtMyTransform()
    {
        GameObject gameObject = Instantiate(prefab, transform.position, transform.rotation);
    }
}
