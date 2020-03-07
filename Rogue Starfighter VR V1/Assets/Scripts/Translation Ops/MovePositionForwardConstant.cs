using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionForwardConstant : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        Vector3 globalVelocity = transform.forward * speed * Time.deltaTime;
        Vector3 targetPosition = rb.position + globalVelocity;
        rb.MovePosition(targetPosition);
    }
}
