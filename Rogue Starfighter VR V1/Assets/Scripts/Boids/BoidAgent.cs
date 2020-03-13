using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(SteeringSystem))]
public class BoidAgent : MonoBehaviour
{

    BoidFlock agentFlock;
    public BoidFlock AgentFlock { get { return agentFlock; } }

    Collider agentCollider;
    public Collider AgentCollider { get { return agentCollider; } }


    public float maxRotationDeltaDegrees = 30;
    private SteeringSystem steeringSystem;

    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider>();
        steeringSystem = GetComponent<SteeringSystem>();
    }

    public void Initialize(BoidFlock flock)
    {
        agentFlock = flock;
    }

    public void SetDeltaRotation(Vector3 desiredForward)
    {
        Quaternion desiredRotation = Quaternion.LookRotation(desiredForward);
        Quaternion deltaRotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, maxRotationDeltaDegrees);
        steeringSystem.deltaRotation = deltaRotation;
    }
}
