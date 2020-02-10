using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictRotation : MonoBehaviour
{
    [SerializeField] Vector3 maxRotationDegrees = default;

    Vector3 restrictedRotationEuler;

    private void LateUpdate()
    {
        // initialize to existing transform
        restrictedRotationEuler = transform.localRotation.eulerAngles;

        // convert [-360, 360] euler to [-180, 180] euler
        if (restrictedRotationEuler.x > 180)  restrictedRotationEuler.x -= 360;
        if (restrictedRotationEuler.x < -180) restrictedRotationEuler.x += 360;
        if (restrictedRotationEuler.y > 180)  restrictedRotationEuler.y -= 360;
        if (restrictedRotationEuler.y < -180) restrictedRotationEuler.y += 360;
        if (restrictedRotationEuler.z > 180)  restrictedRotationEuler.z -= 360;
        if (restrictedRotationEuler.z < -180) restrictedRotationEuler.z += 360;

        // check pitch
        if (restrictedRotationEuler.x >  maxRotationDegrees.x && restrictedRotationEuler.x <= 180)
            restrictedRotationEuler.x =  maxRotationDegrees.x;
        if (restrictedRotationEuler.x < -maxRotationDegrees.x)
            restrictedRotationEuler.x = -maxRotationDegrees.x;

        // check heading
        if (restrictedRotationEuler.y >  maxRotationDegrees.y)
            restrictedRotationEuler.y =  maxRotationDegrees.y;
        if (restrictedRotationEuler.y < -maxRotationDegrees.y)
            restrictedRotationEuler.y = -maxRotationDegrees.y;

        // check roll
        if (restrictedRotationEuler.z >  maxRotationDegrees.z)
            restrictedRotationEuler.z =  maxRotationDegrees.z;
        if (restrictedRotationEuler.z < -maxRotationDegrees.z)
            restrictedRotationEuler.z = -maxRotationDegrees.z;

        // set rotation to restricted rotation
        if (restrictedRotationEuler != transform.eulerAngles)
            transform.localRotation = Quaternion.Euler(restrictedRotationEuler);
    }
}
