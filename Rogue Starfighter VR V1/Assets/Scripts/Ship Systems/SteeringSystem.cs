using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringSystem : MonoBehaviour
{
    public Vector3 rotationScaleEuler;

    [HideInInspector]
    public Quaternion deltaRotation;

    private Vector3 deltaRotationEuler;

    void FixedUpdate()
    {
        // convert deltaRotation to Euler in range [-180, 180]
        deltaRotationEuler = deltaRotation.eulerAngles;
        
        // TODO: extract this code to a library function
        if (deltaRotationEuler.x > 180)  deltaRotationEuler.x -= 360;
        if (deltaRotationEuler.x < -180) deltaRotationEuler.x += 360;
        if (deltaRotationEuler.y > 180)  deltaRotationEuler.y -= 360;
        if (deltaRotationEuler.y < -180) deltaRotationEuler.y += 360;
        if (deltaRotationEuler.z > 180)  deltaRotationEuler.z -= 360;
        if (deltaRotationEuler.z < -180) deltaRotationEuler.z += 360;


        transform.localRotation *= Quaternion.Euler(Vector3.Scale(deltaRotationEuler, rotationScaleEuler));
    }
}
