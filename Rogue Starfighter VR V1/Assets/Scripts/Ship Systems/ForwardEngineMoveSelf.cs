using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardEngineMoveSelf : ForwardEngineAbstract
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = rb.position + internalCurrentVelocity;
        rb.MovePosition(targetPosition);
    }
}
