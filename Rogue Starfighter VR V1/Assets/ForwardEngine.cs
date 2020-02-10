using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardEngine : MonoBehaviour
{
    [Tooltip("The target to move forward")]
    [SerializeField] private Rigidbody targetRigidbody = default;
    [SerializeField] private Transform targetForwardRotation = default;
    [SerializeField] private float topSpeed = default;
    //[SerializeField] private float maxAcceleration;

    private float desiredSpeed;
    public float currentSpeed;

    private void Start()
    {
        desiredSpeed = topSpeed;
        currentSpeed = desiredSpeed;
    }

    private void LateUpdate()
    {
        Vector3 globalVelocity = targetForwardRotation.forward * currentSpeed * Time.deltaTime;
        Vector3 targetPosition = targetRigidbody.position + globalVelocity;
        //targetTransform.Translate(globalVelocity);
        targetRigidbody.MovePosition(targetPosition);
        //target.velocity = target.transform.TransformDirection(localVelocity);  // for kinematic bodies
    }
}
