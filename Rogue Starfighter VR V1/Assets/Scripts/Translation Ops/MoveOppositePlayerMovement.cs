using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOppositePlayerMovement : MonoBehaviour
{
    private void Update()
    {
        Vector3 playerRotationForward = PlayerGlobalReference.I.shipRotationRoot.forward;
        float playerSpeed = PlayerGlobalReference.I.forwardEnginePlayerRef.CurrentSpeed;

        Vector3 playerGlobalVelocity = playerRotationForward * playerSpeed * Time.deltaTime;
        Vector3 targetPosition = transform.position + -playerGlobalVelocity;

        transform.position = targetPosition;
    }
}
