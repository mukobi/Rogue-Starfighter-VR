using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringSystemDeltaRotationToLocalRot : MonoBehaviour
{
    [SerializeField] private GenericSteeringSystem steeringSystem = default;
    [SerializeField] private Vector3 scaleEuler = default;

    private void Update()
    {
        transform.localRotation = Quaternion.Euler(
            Vector3.Scale(
                steeringSystem.deltaRotationLocalEuler, 
                scaleEuler));
    }
}
