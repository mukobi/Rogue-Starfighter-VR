using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(SteeringSystem))]
public abstract class BoidAgent : MonoBehaviour
{
    BoidFlock agentFlock;

    public BoidFlock AgentFlock { get { return agentFlock; } }

    Collider agentCollider;
    public Collider AgentCollider { get { return agentCollider; } }


    public float maxRotationDeltaDegrees = 15;
    private SteeringSystem steeringSystem;

    // for debug
    private Quaternion desiredRotation;
    private Quaternion deltaRotation;

    private readonly bool drawVisionSpheres = false;
    private readonly bool drawRotationGizmos = true;

    // Start is called before the first frame update
    protected virtual void Start()
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
        desiredForward.Normalize();
        desiredRotation = Quaternion.LookRotation(desiredForward);
        desiredRotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, maxRotationDeltaDegrees);
        deltaRotation = desiredRotation * Quaternion.Inverse(transform.rotation);
        Debug.Log(Quaternion.Angle(transform.rotation, deltaRotation));
        //deltaRotation = Quaternion.Inverse(transform.rotation) * deltaRotation;
        steeringSystem.deltaRotation = deltaRotation;
    }

    private void OnDrawGizmosSelected()
    {
        if (drawVisionSpheres && agentFlock != null)
        {
            // draw awareness sphere
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, agentFlock.neighborRadius);
            // draw avoidance sphere
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, agentFlock.neighborRadius * agentFlock.avoidanceRadiusMultiplier);
        }
    }

    private void OnDrawGizmos()
    {
        if (drawRotationGizmos) {
            // forward direction
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + 5 * transform.forward);

            // desired forward
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + 5 * (desiredRotation * Vector3.forward));

            // forward after a second
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, transform.position + 7 * (deltaRotation * transform.forward));
        }
    }
}
