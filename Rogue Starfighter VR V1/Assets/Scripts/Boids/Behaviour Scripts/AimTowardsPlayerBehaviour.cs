using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTowardsPlayerBehaviour : BoidBehaviour
{
    private GameObject player;

    public override Vector3 CalculateDesiredForward(BoidAgent agent, List<Transform> context, BoidFlock flock)
    {
        return (player.transform.position - agent.transform.position).normalized;
    }
}
