﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Cohesion")]
public class CohesionBehavior : FilteredBoidBehaviour
{
    public override Vector3 CalculateDesiredForward(BoidAgent agent, List<Transform> context, BoidFlock flock)
    {
        //if no neighbors, return no adjustment
        if (context.Count == 0)
            return Vector3.zero;

        //add all points together and average
        Vector3 cohesionMove = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        for (int i = 0; i < filteredContext.Count; i++)
        {
            Transform item = filteredContext[i];
            cohesionMove += item.position;
        }
        cohesionMove /= context.Count;

        //create offset from agent position
        cohesionMove -= agent.transform.position;
        return cohesionMove;
    }
}
