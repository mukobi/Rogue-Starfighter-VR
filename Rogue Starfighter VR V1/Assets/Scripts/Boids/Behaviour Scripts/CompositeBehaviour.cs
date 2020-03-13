using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
public class CompositeBehaviour : BoidBehaviour
{
    public BoidBehaviour[] behaviors;
    public float[] weights;

    public override Vector3 CalculateDesiredForward(BoidAgent agent, List<Transform> context, BoidFlock flock)
    {
        //handle data mismatch
        if (weights.Length != behaviors.Length)
        {
            Debug.LogError("Data mismatch in " + name, this);
            return Vector3.zero;
        }

        //set up desired forward
        Vector3 desiredForward = Vector3.zero;

        //iterate through behaviors
        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector3 partialDesiredForward = behaviors[i].CalculateDesiredForward(agent, context, flock) * weights[i];

            if (partialDesiredForward != Vector3.zero)
            {
                // TODO: experiment without this if block
                if (partialDesiredForward.sqrMagnitude > weights[i] * weights[i])
                {
                    partialDesiredForward.Normalize();
                    partialDesiredForward *= weights[i];
                }

                desiredForward += partialDesiredForward;

            }
        }

        return desiredForward;


    }
}
