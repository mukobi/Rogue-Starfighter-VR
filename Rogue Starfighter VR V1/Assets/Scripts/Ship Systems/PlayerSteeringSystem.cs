using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSteeringSystem : GenericSteeringSystem
{

    void Update()
    {
        // convert deltaRotation to Euler in range [-180, 180]
        deltaRotationLocal.Normalize();
        deltaRotationLocalEuler = deltaRotationLocal.eulerAngles;
        
        // TODO: extract this code to a library function
        if (deltaRotationLocalEuler.x > 180)  deltaRotationLocalEuler.x -= 360;
        if (deltaRotationLocalEuler.x < -180) deltaRotationLocalEuler.x += 360;
        if (deltaRotationLocalEuler.y > 180)  deltaRotationLocalEuler.y -= 360;
        if (deltaRotationLocalEuler.y < -180) deltaRotationLocalEuler.y += 360;
        if (deltaRotationLocalEuler.z > 180)  deltaRotationLocalEuler.z -= 360;
        if (deltaRotationLocalEuler.z < -180) deltaRotationLocalEuler.z += 360;

        // This line is the only difference from GenericSteeringSystem
        transform.localRotation = transform.localRotation * Quaternion.Euler(Vector3.Scale(deltaRotationLocalEuler, rotationScaleLocalEuler));
    }
}
