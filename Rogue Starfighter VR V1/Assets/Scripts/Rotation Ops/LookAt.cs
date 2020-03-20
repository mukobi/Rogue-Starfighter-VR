using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] public Transform targetToLookAt;
    [Tooltip("Who's up direction to use. Leave blank if you don't care about z-axis rotation.")]
    [SerializeField] public Transform targetUp;

    private void Update()
    {
        if(targetUp != null)
        {
            transform.LookAt(targetToLookAt, targetUp.up);
        }
        else
        {
            transform.LookAt(targetToLookAt);
        }
    }
}
