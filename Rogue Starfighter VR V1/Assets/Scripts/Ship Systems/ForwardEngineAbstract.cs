﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ForwardEngineAbstract : MonoBehaviour
{
    [SerializeField] private float baseCruiseSpeed;
    public float BaseCruiseSpeed { get { return baseCruiseSpeed; } set { baseCruiseSpeed = value; } }

    public float SpeedAtInstantiation;
    public float SpeedBoost { get; set; }
    public float TurnSpeedReduction { get; set; }
    [SerializeField] private float maxPositiveAcceleration = 1;

    private float internalTargetSpeed;
    public float CurrentSpeed { get; private set; }

    protected Vector3 internalCurrentVelocity;

    private void Start()
    {
        CurrentSpeed = SpeedAtInstantiation;
    }

    protected virtual void Update()
    {
        // calculate internalTargetSpeed
        internalTargetSpeed = baseCruiseSpeed + SpeedBoost - TurnSpeedReduction;

        // update my CurrentSpeed
        float speedDifference = internalTargetSpeed - CurrentSpeed;
        float currentAcceleration = 0;
        if (speedDifference > 0)
        {
            currentAcceleration = maxPositiveAcceleration;
            // clamp positive acc to [0, speedDifference]
            currentAcceleration = Mathf.Clamp(currentAcceleration, 0, speedDifference);
        }
        else if (speedDifference < 0)
        {
            currentAcceleration = -maxPositiveAcceleration;
            // clamp negative acc to [speedDifference, 0]
            currentAcceleration = Mathf.Clamp(currentAcceleration, speedDifference, 0);
        }

        CurrentSpeed += currentAcceleration;

        // calculate internalCurrentVelocity so child classes can move based off of it
        internalCurrentVelocity = transform.forward * CurrentSpeed * Time.deltaTime;
    }
}
