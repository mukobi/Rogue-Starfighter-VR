using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicShipSystemAbstract : MonoBehaviour, IShipSystem
{
    protected bool shipSystemIsDisabled = false;

    public virtual void DisableSystem()
    {
        shipSystemIsDisabled = true;
    }

    public virtual void RepairSystem()
    {
        shipSystemIsDisabled = false;
    }
}
