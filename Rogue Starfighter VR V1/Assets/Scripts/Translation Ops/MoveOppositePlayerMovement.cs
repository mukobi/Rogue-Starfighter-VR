using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveOppositePlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 playerRotationForward = PlayerGlobalReference.Instance.rotationRoot.forward;
        float playerSpeed = PlayerGlobalReference.Instance.forwardEnginePlayerRef.CurrentSpeed;

        Vector3 playerGlobalVelocity = playerRotationForward * playerSpeed * Time.fixedDeltaTime;
        Vector3 targetPosition = transform.position + -playerGlobalVelocity;

        rb.MovePosition(targetPosition);
    }
}
