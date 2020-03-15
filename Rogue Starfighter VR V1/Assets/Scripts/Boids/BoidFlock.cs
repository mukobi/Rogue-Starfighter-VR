using System.Collections.Generic;
using UnityEngine;

public abstract class BoidFlock : MonoBehaviour
{
    public List<BoidAgent> agents = new List<BoidAgent>();
    public BoidBehaviour behavior;

    public float neighborRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    // Start is called before the first frame update
    void Start()
    {
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < agents.Count; i++)
        {
            BoidAgent agent = agents[i];
            //if (agent == null)
            //{
            //    agents.Remove(agent);
            //}
            List<Transform> context = GetNearbyObjects(agent);

            Vector3 desiredForward = behavior.CalculateDesiredForward(agent, context, this);
            agent.SetDeltaRotation(desiredForward);
        }
    }

    List<Transform> GetNearbyObjects(BoidAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighborRadius);
        for (int i = 0; i < contextColliders.Length; i++)
        {
            Collider c = contextColliders[i];
            if (c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }
}
