using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalRotateTowardsSlerp : MonoBehaviour
{
    [Range(0,1)]
    public float slerpFactor = 1;

    [Tooltip("Difference angle below which I'll just snap to the target rotation.")]
    public float instantSnapAngleDegrees = 1;

    [Tooltip("If None, will use the public Quaternion TargetRotation as target")]
    [SerializeField] Transform TargetTransform = default;

    [HideInInspector]
    public Quaternion TargetRotation;

    void LateUpdate()
    {
        if (TargetTransform)
            TargetRotation = TargetTransform.localRotation;

        if (Quaternion.Angle(transform.localRotation, TargetRotation) < instantSnapAngleDegrees)
        {
            transform.localRotation = TargetRotation;
        }
        else
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, TargetRotation, slerpFactor);
        }
    }
}
