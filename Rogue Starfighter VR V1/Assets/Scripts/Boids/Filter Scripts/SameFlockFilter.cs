using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/Same Flock")]
public class SameFlockFilter : ContextFilter
{
    public override List<Transform> Filter(BoidAgent agent, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        for (int i = 0; i < original.Count; i++)
        {
            Transform item = original[i];
            BoidAgent itemAgent = item.GetComponent<BoidAgent>();
            if (itemAgent != null && itemAgent.AgentFlock == agent.AgentFlock)
            {
                filtered.Add(item);
            }
        }
        return filtered;
    }
}
