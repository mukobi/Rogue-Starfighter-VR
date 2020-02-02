using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapSmallLocalRotationToZerp : MonoBehaviour
{
    [Tooltip("The Euler sqr magnitude below which rotations will go to 0.")]
    [SerializeField] float limitSqrMagnitide;

    private Vector3 localRotationEuler;

    private void FixedUpdate()
    {
        localRotationEuler = transform.localRotation.eulerAngles;

        // convert [-360, 360] euler to [-180, 180] euler
        if (localRotationEuler.x > 180)  localRotationEuler.x -= 360;
        if (localRotationEuler.x < -180) localRotationEuler.x += 360;
        if (localRotationEuler.y > 180)  localRotationEuler.y -= 360;
        if (localRotationEuler.y < -180) localRotationEuler.y += 360;
        if (localRotationEuler.z > 180)  localRotationEuler.z -= 360;
        if (localRotationEuler.z < -180) localRotationEuler.z += 360;

        Debug.Log(localRotationEuler);
        Debug.Log(localRotationEuler.sqrMagnitude);
        if (transform.localRotation != Quaternion.identity
            && localRotationEuler.sqrMagnitude < limitSqrMagnitide)
        {
            Debug.Log("reset rotation");
            transform.localRotation = Quaternion.identity;
        }
    }
}
