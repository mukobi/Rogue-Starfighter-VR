using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalRotateTowardsSlerp : MonoBehaviour
{
    [Range(0,1)]
    public float slerpFactor = 1;

    [Tooltip("If None, will use the public Quaternion TargetRotation as target")]
    [SerializeField] 
    Transform TargetTransform;

    [HideInInspector]
    public Quaternion TargetRotation;

    void FixedUpdate()
    {
        if (TargetTransform)
            TargetRotation = TargetTransform.localRotation;

        if(transform.localRotation != TargetRotation)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, TargetRotation, slerpFactor);
        }
    }
}
