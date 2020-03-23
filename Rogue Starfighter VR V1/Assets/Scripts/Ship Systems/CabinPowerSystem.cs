using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinPowerSystem : ShipSystemAbstract
{
    public DimmableAbstract[] dimmables;

    public override string GetShipSystemName => "Cabin Power";

    public override void DisableSystem()
    {
        base.DisableSystem();
        for (int i = 0; i < dimmables.Length; i++)
        {
            // TODO: tween with a library instead for flicker effect
            dimmables[i].DimmableValue01 = 0;
        }
    }

    public override void RepairSystem()
    {
        base.RepairSystem();
        for (int i = 0; i < dimmables.Length; i++)
        {
            // TODO: tween with a library instead for flicker effect
            dimmables[i].DimmableValue01 = 1;
        }
    }
}
