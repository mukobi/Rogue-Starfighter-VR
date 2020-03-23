using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicShipSystemAbstract : MonoBehaviour, IShipSystem
{
    protected bool shipSystemIsDisabled = false;

    public void DisableSystem()
    {
        shipSystemIsDisabled = true;
    }

    public void RepairSystem()
    {
        shipSystemIsDisabled = false;
    }
}
