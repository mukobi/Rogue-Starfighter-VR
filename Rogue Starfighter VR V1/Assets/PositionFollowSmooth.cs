using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFollowSmooth : MonoBehaviour
{
    [SerializeField] private Transform target = default;
    [SerializeField] private float smoothTime = 0.1f;

    private Vector3 velocity;

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
    }
}
