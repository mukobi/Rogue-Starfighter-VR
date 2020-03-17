using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpInFromHyperspaceOnStart : MonoBehaviour
{
    public float JumpDistance;
    public float LerpPerFrame = 0.5f;

    private Vector3 initialPosition;

    private IEnumerator Start()
    {
        initialPosition = transform.position;
        transform.position -= JumpDistance * transform.forward;
        yield return null;
        while ((transform.position - initialPosition).sqrMagnitude > 1)
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition, LerpPerFrame);
            yield return null;
        }
        transform.position = initialPosition;
    }
}
