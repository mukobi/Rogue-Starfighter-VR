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
        if (agent.PlayerRelative.ToPlayerSqrMagnitude < squareMinDistToAim)
        {
            Debug.Log("ToPlayerSqrMagnitude");
            return Vector3.zero;
        }
        if (agent.PlayerRelative.AngleToPlayer > maxAngleToAim)
        {
            Debug.Log("AngleToPlayer");
            return Vector3.zero;
        }
        return agent.PlayerRelative.ToPlayerNormalized;
    }
}
