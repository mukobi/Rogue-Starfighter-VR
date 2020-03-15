using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/AimTowardsPlayer")]
public class AimTowardsPlayerBehaviour : BoidBehaviour
{
    [Tooltip("Won't aim at player when angle to player is outside this.")]
    public float maxAngleToAim;
    
    public override Vector3 CalculateDesiredForward(BoidAgent agent, List<Transform> context, BoidFlock flock)
    {
        Vector3 dirToPlayerNorm = (PlayerGlobalReference.I.shipRotationRoot.position - agent.transform.position).normalized;
        if (Vector3.Angle(agent.transform.forward, dirToPlayerNorm) > maxAngleToAim)
            return Vector3.zero;
        return dirToPlayerNorm;
    }
}
