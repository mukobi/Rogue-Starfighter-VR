using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSteeringSystem : MonoBehaviour
{
    public Vector3 rotationScaleLocalEuler;

    [HideInInspector]
    public Quaternion deltaRotationLocal;

    protected Vector3 deltaRotationLocalEuler;
    protected Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
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

        rb.MoveRotation(Quaternion.Euler(Vector3.Scale(deltaRotationLocalEuler, rotationScaleLocalEuler)) * transform.localRotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + 17 * (deltaRotationLocal * transform.forward));
    }
}
