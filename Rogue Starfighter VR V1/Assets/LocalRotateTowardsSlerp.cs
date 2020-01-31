using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalRotateTowardsSlerp : MonoBehaviour
{
    [Range(0,1)]
    public float slerpFactor = 1;

    [HideInInspector]
    public Quaternion TargetRotation;

    void FixedUpdate()
    {
        if(transform.localRotation != TargetRotation)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, TargetRotation, slerpFactor);
        }
    }
}
