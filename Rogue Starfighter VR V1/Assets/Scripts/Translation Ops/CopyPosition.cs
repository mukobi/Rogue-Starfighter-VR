using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPosition : MonoBehaviour
{
    [SerializeField] private Transform target = default;

    private void Update()
    {
        transform.position = target.position;
    }
}
