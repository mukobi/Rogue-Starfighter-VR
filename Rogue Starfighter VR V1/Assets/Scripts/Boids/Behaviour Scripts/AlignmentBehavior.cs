using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class AlignmentBehavior : FilteredBoidBehavior
{
    public override Vector3 CalculateDesiredForward(BoidAgent agent, List<Transform> context, BoidFlock flock)
    {
        //if no neighbors, maintain current alignment
        if (context.Count == 0)
            return agent.transform.forward;

        //add all points together and average
        Vector3 alignmentDirection = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        for (int i = 0; i < filteredContext.Count; i++)
        {
            Transform item = filteredContext[i];
            alignmentDirection += item.transform.forward;
        }
        alignmentDirection /= context.Count;

        return alignmentDirection;
    }
}
