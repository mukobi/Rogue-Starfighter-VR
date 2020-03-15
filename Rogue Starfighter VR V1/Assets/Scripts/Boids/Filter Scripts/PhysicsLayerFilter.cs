using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/Physics Layer")]
public class PhysicsLayerFilter : ContextFilter
{
    public LayerMask mask;

    public override List<Transform> Filter(BoidAgent agent, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        for (int i = 0; i < original.Count; i++)
        {
            Transform item = original[i];
            if (mask == (mask | (1 << item.gameObject.layer)))
            {
                filtered.Add(item);
            }
        }
        return filtered;
    }
}
