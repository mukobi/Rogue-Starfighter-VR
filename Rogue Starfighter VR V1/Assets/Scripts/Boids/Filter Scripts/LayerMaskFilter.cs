using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Filter/Layer Mask")]
public class LayerMaskFilter : ContextFilter
{
    public LayerMask layerMask;
    public override List<Transform> Filter(BoidAgent agent, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        for (int i = 0; i < original.Count; i++)
        {
            Transform item = original[i];
            if ((layerMask & 1 << item.gameObject.layer) != 0)
            {
                filtered.Add(item);
            }
        }
        return filtered;
    }
}
