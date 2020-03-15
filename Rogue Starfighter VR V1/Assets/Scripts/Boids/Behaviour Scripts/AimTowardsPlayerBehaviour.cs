using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTowardsPlayerBehaviour : BoidBehaviour
{
    public override Vector3 CalculateDesiredForward(BoidAgent agent, List<Transform> context, BoidFlock flock)
    {
        return (PlayerGlobalReference.I.shipRotationRoot.position - agent.transform.position).normalized;
    }
}
