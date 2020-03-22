
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartialSlerpLocalRotation : MonoBehaviour
{
    [SerializeField] private Transform target = default;
    [SerializeField] private bool copyX = false;
    [SerializeField] private bool copyY = false;
    [SerializeField] private bool copyZ = false;

    [SerializeField] private float slerpFactor = 1.0f;

    private void Update()
    {
        Vector3 targetRotEuler = target.localEulerAngles;
        Vector3 myRotEuler = transform.localEulerAngles;

        Quaternion desiredLocalRot = Quaternion.Euler(
            copyX ? targetRotEuler.x : myRotEuler.x,
            copyY ? targetRotEuler.y : myRotEuler.y,
            copyZ ? targetRotEuler.z : myRotEuler.z);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, desiredLocalRot, slerpFactor);
    }
}
