using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Stay In Radius")]
public class StayInRadiusBehavior : BoidBehaviour
{
    public float radius = 1000f;

    public override Vector3 CalculateDesiredForward(BoidAgent agent, List<Transform> context, BoidFlock flock)
    {
        Vector3 centerOffset = agent.AgentFlock.transform.position - agent.transform.position;
        float t = centerOffset.magnitude / radius;
        if (t < 0.95f)
        {
            return Vector3.zero;
        }

        return centerOffset * t * t;
    }
}
