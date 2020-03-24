using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardEngineMoveSelf : ForwardEngine
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected override void Update()
    {
        base.Update();
        Vector3 targetPosition = transform.position + internalCurrentVelocity;
        transform.position = targetPosition;
        //    rb.MovePosition(targetPosition); // has issues when childed to a MoveOppositePlayerMovement object
    }
}
