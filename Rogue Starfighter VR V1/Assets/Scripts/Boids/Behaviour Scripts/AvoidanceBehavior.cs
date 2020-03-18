using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
public class AvoidanceBehavior : FilteredBoidBehaviour
{
    public float avoidanceRange;
    private float squareAvoidanceRange;

    public override void Initialize()
    {
        squareAvoidanceRange = avoidanceRange * avoidanceRange;
        //Debug.Log(squareAvoidanceRange);
    }

    public override Vector3 CalculateDesiredForward(BoidAgent agent, List<Transform> context, BoidFlock flock)
    {
        Profiler.BeginSample("Avoidance setup");

        //if no neighbors, return no adjustment
        if (context.Count == 0)
            return Vector3.zero;

        Profiler.EndSample();


        Profiler.BeginSample("Avoidance filter");

        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);

        Profiler.EndSample();


        Profiler.BeginSample("Avoidance calculation");

        //add all points together and average
        Vector3 avoidanceMove = Vector3.zero;
        int nAvoid = 0;
        for (int i = 0; i < filteredContext.Count; i++)
        {
            Transform item = filteredContext[i];

            Profiler.BeginSample("squareDistance");
            float squareDistance = Vector3.SqrMagnitude(item.position - agent.transform.position);
            Profiler.EndSample();
            Profiler.BeginSample("compare distance");
            if (squareDistance < squareAvoidanceRange)
            {
                Profiler.BeginSample("calculate single move");
                nAvoid++;
                avoidanceMove += -(item.position - agent.transform.position).normalized;
                Profiler.EndSample();
            }
            Profiler.EndSample();
        }
        if (nAvoid > 0)
            avoidanceMove /= nAvoid;

        Profiler.EndSample();

        return avoidanceMove;
    }
}
