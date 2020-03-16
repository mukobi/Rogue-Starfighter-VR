using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownEngineBasedOnTurning : MonoBehaviour
{
    [Tooltip("Steering system with delta rotation to read.")]
    [SerializeField] private SteeringSystem steeringSystem = default;
    [Tooltip("Engine with turning slowdown to write.")]
    [SerializeField] private ForwardEngineAbstract forwardEngine = default;

    [SerializeField] private float maxSpeedSlowdown = default;
    [SerializeField] private float angleOfMaxSlowdownDegrees = default;

    private void FixedUpdate()
    {
        // calculate how much we're turning
        float turnAngleDegrees = Quaternion.Angle(steeringSystem.deltaRotationLocal, Quaternion.identity);

        // calculate appropriate slowdown
        turnAngleDegrees = Mathf.Clamp(turnAngleDegrees, 0, angleOfMaxSlowdownDegrees);
        float turnSpeedReduction = (turnAngleDegrees / angleOfMaxSlowdownDegrees) * maxSpeedSlowdown;

        // apply slowdown to engine
        forwardEngine.TurnSpeedReduction = turnSpeedReduction;
    }
}
