using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerRelativeTransformCalculator))]
public class FireWhenAimingAtPlayer : MonoBehaviour
{
    public float maxAngleAwayToFire;

    public FireableController fireableController;
    private PlayerRelativeTransformCalculator playerRelativeTransformCalculator;

    private void Start()
    {
        playerRelativeTransformCalculator = GetComponent<PlayerRelativeTransformCalculator>();
    }

    private void FixedUpdate()
    {
        fireableController.isTryingToFire = playerRelativeTransformCalculator.AngleToPlayer < maxAngleAwayToFire;
    }
}
