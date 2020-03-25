using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using System.Threading;
using System.Threading.Tasks;

public class HyperdriveSwitchController : MonoBehaviour
{
    [Header("Dependencies")]
    public CircularDrive switchCircularDrive;

    [Header("Config")]
    [SerializeField] private Vector2 lockedInitialMinMaxAngles = default;
    [SerializeField] private Vector2 lockedForwardMinMaxAngles = default;
    [SerializeField] private Vector2 freeMinMaxAngles = default;


    public bool SwitchHasBeenThrowMarker { get; set; } = false;

    private bool isLocked = true;

    public async Task RequireSwitchThrown(CancellationToken ct)
    {
        FreeSwitch();
        SwitchHasBeenThrowMarker = false;
        while (!ct.IsCancellationRequested && !SwitchHasBeenThrowMarker)
        {
            await Task.Delay(50);
        }
        SwitchHasBeenThrowMarker = false;
    }

    public void RotateSwitchToPosition(float rotation)
    {

    }
    
    private void LockSwitchInInitialPosition()
    {
        isLocked = true;
        switchCircularDrive.minAngle = lockedInitialMinMaxAngles.x;
        switchCircularDrive.maxAngle = lockedInitialMinMaxAngles.y;
        RotateSwitchToPosition(lockedInitialMinMaxAngles.x);
    }

    private void LockSwitchInForwardPosition()
    {
        isLocked = true;
        switchCircularDrive.minAngle = lockedForwardMinMaxAngles.x;
        switchCircularDrive.maxAngle = lockedForwardMinMaxAngles.y;
        RotateSwitchToPosition(lockedForwardMinMaxAngles.x);
    }

    private void FreeSwitch()
    {
        isLocked = true;
        switchCircularDrive.minAngle = freeMinMaxAngles.x;
        switchCircularDrive.maxAngle = freeMinMaxAngles.y;
    }
}
