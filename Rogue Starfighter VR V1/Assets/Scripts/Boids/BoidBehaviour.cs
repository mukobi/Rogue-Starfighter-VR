using System.Collections.Generic;
using UnityEngine;

public abstract class BoidBehaviour : ScriptableObject
{
    public abstract Vector3 CalculateDesiredForward(BoidAgent agent, List<Transform> context, BoidFlock flock);

    public virtual void Initialize() { } // runtime initialization e.g. caching
}
