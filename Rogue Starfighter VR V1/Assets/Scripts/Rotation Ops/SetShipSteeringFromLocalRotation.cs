using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShipSteeringFromLocalRotation : MonoBehaviour
{
    // TODO: change this into an interface
    [SerializeField] SteeringSystem steeringSystem = default;

    private void FixedUpdate()
    {
        steeringSystem.deltaRotationLocal = transform.localRotation;
    }
}
