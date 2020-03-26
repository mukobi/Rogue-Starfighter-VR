using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpInFromHyperspaceOnEnable : MonoBehaviour
{
    public float JumpDistance;
    public float LerpPerFrame = 0.5f;

    private Vector3 initialPosition;

    private void OnEnable()
    {
        StartCoroutine(JumpInCoroutine());
    }

    private IEnumerator JumpInCoroutine()
    {
        initialPosition = transform.position;
        transform.position -= JumpDistance * transform.forward;
        yield return null;
        while ((transform.position - initialPosition).sqrMagnitude > 24)
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition, LerpPerFrame);
            yield return null;
        }
        transform.position = initialPosition;
    }
}
