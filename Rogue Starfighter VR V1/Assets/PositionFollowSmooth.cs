using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFollowSmooth : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.1f;

    private Vector3 velocity;

    private void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
    }
}
