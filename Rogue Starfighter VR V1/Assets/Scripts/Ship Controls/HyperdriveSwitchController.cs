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

    private bool isLocked = true;

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
        isLocked = true;
        switchRotator.minAngle = lockedInitialMinMaxAngles.x;
        switchRotator.maxAngle = lockedInitialMinMaxAngles.y;
        RotateSwitchToPosition(lockedInitialMinMaxAngles.x);
    }

    public void LockSwitchInForwardPosition()
    {
        isLocked = true;
        switchRotator.minAngle = lockedForwardMinMaxAngles.x;
        switchRotator.maxAngle = lockedForwardMinMaxAngles.y;
        RotateSwitchToPosition(lockedForwardMinMaxAngles.x);
    }

    public void FreeSwitch()
    {
        isLocked = true;
        switchRotator.minAngle = freeMinMaxAngles.x;
        switchRotator.maxAngle = freeMinMaxAngles.y;
    }
}
