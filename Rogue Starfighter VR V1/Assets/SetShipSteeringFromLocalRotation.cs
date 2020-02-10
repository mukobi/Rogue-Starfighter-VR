using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShipSteeringFromLocalRotation : MonoBehaviour
{
    [SerializeField] SteeringSystem steeringSystem = default;

    private void FixedUpdate()
    {
        steeringSystem.deltaRotation = transform.localRotation;
    }
}
