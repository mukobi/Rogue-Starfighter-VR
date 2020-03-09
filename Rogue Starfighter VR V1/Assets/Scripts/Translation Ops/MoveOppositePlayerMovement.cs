using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOppositePlayerMovement : MonoBehaviour
{
    private void Update()
    {
        Vector3 playerRotationForward = PlayerGlobalReference.Instance.rotationRoot.forward;
        float playerSpeed = PlayerGlobalReference.Instance.forwardEnginePlayerRef.CurrentSpeed;

        Vector3 playerGlobalVelocity = playerRotationForward * playerSpeed * Time.fixedDeltaTime;
        Vector3 targetPosition = transform.position + -playerGlobalVelocity;

        transform.position = targetPosition;
    }
}
