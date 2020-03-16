using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/AimTowardsPlayer")]
public class AimTowardsPlayerBehaviour : BoidBehaviour
{
    [Tooltip("Won't aim at player when angle to player is outside this.")]
    public float maxAngleToAim;

    public float minDistToAim;
    private float squareMinDistToAim;

    [RuntimeInitializeOnLoadMethod]
    private void RuntimeInitializeOnLoad()
    {
        squareMinDistToAim = minDistToAim * minDistToAim;
    }
    
    public override Vector3 CalculateDesiredForward(BoidAgent agent, List<Transform> context, BoidFlock flock)
    {
        Vector3 dirToPlayer = PlayerGlobalReference.I.shipRotationRoot.position - agent.transform.position;
        if (dirToPlayer.sqrMagnitude < squareMinDistToAim)
            return Vector3.zero;
        Vector3 dirToPlayerNorm = dirToPlayer.normalized;
        if (Vector3.Angle(agent.transform.forward, dirToPlayerNorm) > maxAngleToAim)
            return Vector3.zero;
        return dirToPlayerNorm;
    }
}
