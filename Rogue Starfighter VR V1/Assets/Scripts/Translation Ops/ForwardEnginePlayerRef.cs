using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardEnginePlayerRef : MonoBehaviour
{
    [SerializeField] private float topSpeed = default;
    private float desiredSpeed;
    [SerializeField] public float currentSpeed = default;

    private void Start()
    {
        desiredSpeed = topSpeed;
        currentSpeed = desiredSpeed;
    }
}
