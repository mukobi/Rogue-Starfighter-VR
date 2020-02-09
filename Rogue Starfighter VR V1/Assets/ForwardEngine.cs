using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardEngine : MonoBehaviour
{
    [Tooltip("The target to move forward")]
    [SerializeField] private Rigidbody targetRigidbody;
    [SerializeField] private Transform targetForwardRotation;
    [SerializeField] private float topSpeed;
    //[SerializeField] private float maxAcceleration;

    private float desiredSpeed;
    public float currentSpeed;

    private void Start()
    {
        desiredSpeed = topSpeed;
        currentSpeed = desiredSpeed;
    }

    private void FixedUpdate()
    {
        Vector3 globalVelocity = targetForwardRotation.forward * currentSpeed * Time.deltaTime;
        Vector3 targetPosition = targetRigidbody.transform.position + globalVelocity;
        //targetRigidbody.transform.Translate(globalVelocity);
        targetRigidbody.MovePosition(targetPosition);
        //target.velocity = target.transform.TransformDirection(localVelocity);  // for kinematic bodies
    }
}
