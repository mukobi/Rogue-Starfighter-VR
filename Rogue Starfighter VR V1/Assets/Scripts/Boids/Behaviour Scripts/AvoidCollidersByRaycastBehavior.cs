using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoid Colliders By Raycast")]
public class AvoidCollidersByRaycastBehavior : FilteredBoidBehaviour
{
    public LayerMask layerMask;
    public override Vector3 CalculateDesiredForward(BoidAgent agent, List<Transform> context, BoidFlock flock)
    {
        Profiler.BeginSample("Avoid collider raycast setup");

        //if no neighbors, return no adjustment
        if (context.Count == 0)
            return Vector3.zero;

        Profiler.EndSample();


        Profiler.BeginSample("Avoid collider raycast filter");

        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);

        Profiler.EndSample();


        Profiler.BeginSample("Avoid collider raycast calculation");

        //add all points together and average
        Vector3 avoidanceMove = Vector3.zero;
        int nAvoid = 0;
        for (int i = 0; i < filteredContext.Count; i++)
        {
            Transform item = filteredContext[i];

            Profiler.BeginSample("raycast");
            Vector3 toItem = item.position - agent.transform.position;
            RaycastHit hitInfo;
            if(Physics.Raycast(agent.transform.position, toItem, out hitInfo, flock.neighborRadius, layerMask))
            {
                nAvoid++;
                avoidanceMove += (agent.transform.position - hitInfo.point).normalized;
            }
            Profiler.EndSample();
        }
        if (nAvoid > 0)
            avoidanceMove /= nAvoid;

        Profiler.EndSample();

        return avoidanceMove;
    }
}
