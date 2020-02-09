using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardEngine : MonoBehaviour
{
    [Tooltip("The target to move forward")]
    [SerializeField] private Rigidbody target;
    [SerializeField] private float topSpeed;
    [SerializeField] private float maxAcceleration;

    private float desiredSpeed;
    private float currentSpeed;

    private void Start()
    {
        desiredSpeed = topSpeed;
        currentSpeed = desiredSpeed;
    }

    private void FixedUpdate()
    {
        Vector3 globalVelocity = target.transform.forward * currentSpeed * Time.fixedDeltaTime;
        Vector3 targetPosition = target.transform.position + globalVelocity;
        target.MovePosition(targetPosition);
        //target.velocity = target.transform.TransformDirection(localVelocity);  // for kinematic bodies
    }
}
