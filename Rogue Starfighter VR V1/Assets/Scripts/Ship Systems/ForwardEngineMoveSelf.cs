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

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Vector3 targetPosition = rb.position + internalCurrentVelocity;
        rb.MovePosition(targetPosition);
    }
}
