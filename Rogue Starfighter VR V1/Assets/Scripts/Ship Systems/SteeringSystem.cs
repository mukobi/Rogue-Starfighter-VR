using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringSystem : MonoBehaviour
{
    public Vector3 rotationScaleEuler;

    [HideInInspector]
    public Quaternion deltaRotation;

    private Vector3 deltaRotationEuler;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // convert deltaRotation to Euler in range [-180, 180]
        deltaRotation.Normalize();
        deltaRotationEuler = deltaRotation.eulerAngles;
        
        // TODO: extract this code to a library function
        if (deltaRotationEuler.x > 180)  deltaRotationEuler.x -= 360;
        if (deltaRotationEuler.x < -180) deltaRotationEuler.x += 360;
        if (deltaRotationEuler.y > 180)  deltaRotationEuler.y -= 360;
        if (deltaRotationEuler.y < -180) deltaRotationEuler.y += 360;
        if (deltaRotationEuler.z > 180)  deltaRotationEuler.z -= 360;
        if (deltaRotationEuler.z < -180) deltaRotationEuler.z += 360;


        rb.MoveRotation(Quaternion.Euler(Vector3.Scale(deltaRotationEuler, rotationScaleEuler)) * transform.rotation);
        //rb.MoveRotation(deltaRotation * transform.localRotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + 5 * (deltaRotation * transform.forward));
    }
}
