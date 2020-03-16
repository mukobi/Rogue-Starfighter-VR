using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

[CreateAssetMenu(menuName = "Flock/Behavior/Random")]
public class RandomBehavior : BoidBehaviour
{
    public override Vector3 CalculateDesiredForward(BoidAgent agent, List<Transform> context, BoidFlock flock)
    {
        return new Vector3(
            Random.Range(-1.0f, 1.0f),
            Random.Range(-1.0f, 1.0f),
            Random.Range(-1.0f, 1.0f));
    }
}
