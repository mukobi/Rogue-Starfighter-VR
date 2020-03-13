using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BoidAgent : MonoBehaviour
{

    BoidFlock agentFlock;
    public BoidFlock AgentFlock { get { return agentFlock; } }

    Collider agentCollider;
    public Collider AgentCollider { get { return agentCollider; } }

    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider>();
    }

    public void Initialize(BoidFlock flock)
    {
        agentFlock = flock;
    }

    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
