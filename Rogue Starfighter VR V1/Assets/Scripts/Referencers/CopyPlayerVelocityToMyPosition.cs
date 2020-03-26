using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPlayerVelocityToMyPosition : MonoBehaviour
{
    private void Update()
    {
        Vector3 playerRotationForward = PlayerGlobalReference.I.shipRotationRoot.forward;
        float playerSpeed = PlayerGlobalReference.I.forwardEnginePlayerRef.CurrentSpeed;

        transform.position = playerRotationForward * playerSpeed;
    }
}
