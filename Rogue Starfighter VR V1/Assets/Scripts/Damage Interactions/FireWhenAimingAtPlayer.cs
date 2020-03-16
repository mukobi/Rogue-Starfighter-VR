using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerRelativeTransformCalculator))]
public class FireWhenAimingAtPlayer : MonoBehaviour
{
    public float maxAngleAwayToFire;
    public float maxDistAwayToFire;

    private float sqrMaxDistAwayToFire;

    public FireableController fireableController;
    private PlayerRelativeTransformCalculator playerRelativeTransformCalculator;

    private void Start()
    {
        playerRelativeTransformCalculator = GetComponent<PlayerRelativeTransformCalculator>();
        sqrMaxDistAwayToFire = maxDistAwayToFire * maxDistAwayToFire;
    }

    private void FixedUpdate()
    {
        fireableController.isTryingToFire = (playerRelativeTransformCalculator.AngleToPlayer < maxAngleAwayToFire
            && playerRelativeTransformCalculator.ToPlayerSqrMagnitude < sqrMaxDistAwayToFire);
    }
}
