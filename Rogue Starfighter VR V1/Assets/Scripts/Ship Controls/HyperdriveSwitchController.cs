using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using System.Threading;
using System.Threading.Tasks;

public class HyperdriveSwitchController : MonoBehaviour
{
    [Header("Dependencies")]
    public ThrowSwitch switchRotator;
    public SingleAxisLocalConstantRotation singleAxisLocalConstantRotation;

    [Header("Config")]
    [SerializeField] private Vector2 lockedInitialMinMaxAngles = default;
    [SerializeField] private Vector2 lockedForwardMinMaxAngles = default;
    [SerializeField] private Vector2 freeMinMaxAngles = default;


    public bool SwitchHasBeenThrowMarker { get; set; } = false;

    public async Task RequireSwitchThrown(CancellationToken ct)
    {
        FreeSwitch();
        RotateSwitchToPosition(freeMinMaxAngles.x);
        SwitchHasBeenThrowMarker = false;
        while (!ct.IsCancellationRequested && !SwitchHasBeenThrowMarker)
        {
            await Task.Delay(50);
        }
        SwitchHasBeenThrowMarker = false;
    }

    public void RotateSwitchToPosition(float rotation)
    {
        singleAxisLocalConstantRotation.TargetRotation = rotation;
    }
    
    public void LockSwitchInInitialPosition()
    {
        switchRotator.minAngle = lockedInitialMinMaxAngles.x;
        switchRotator.maxAngle = lockedInitialMinMaxAngles.y;
        RotateSwitchToPosition(lockedInitialMinMaxAngles.x);
    }

    public void LockSwitchInForwardPosition()
    {
        switchRotator.minAngle = lockedForwardMinMaxAngles.x;
        switchRotator.maxAngle = lockedForwardMinMaxAngles.y;
        RotateSwitchToPosition(lockedForwardMinMaxAngles.x);
    }

    public void FreeSwitch()
    {
        switchRotator.minAngle = freeMinMaxAngles.x;
        switchRotator.maxAngle = freeMinMaxAngles.y;
    }
}
