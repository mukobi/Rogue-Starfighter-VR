using System.Collections.Generic;
using UnityEngine;

public class BoidBehaviour : ScriptableObject
{
    public abstract Vector3 CalculateMove(BoidAgent agent, List<Transform> context, BoidFlock flock);
}
