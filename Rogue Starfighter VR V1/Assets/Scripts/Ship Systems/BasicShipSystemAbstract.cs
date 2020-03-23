using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BreakableShipSystemAbstract : MonoBehaviour
{
    public bool shipSystemIsDisabled = false;

    public virtual void DisableSystem()
    {
        shipSystemIsDisabled = true;
    }

    public virtual void RepairSystem()
    {
        shipSystemIsDisabled = false;
    }

    public abstract string GetShipSystemName { get; }
}
