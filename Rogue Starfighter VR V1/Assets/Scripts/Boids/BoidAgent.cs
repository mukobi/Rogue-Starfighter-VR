using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(SteeringSystem))]
public abstract class BoidAgent : MonoBehaviour
{
    BoidFlock agentFlock;

    public BoidFlock AgentFlock { get { return agentFlock; } }

    Collider agentCollider;
    public Collider AgentCollider { get { return agentCollider; } }

    // steering
    [Range(0,1)]
    public float steerChangeSlerpFactor;
    public float maxRotationDeltaDegrees = 15;
    private SteeringSystem steeringSystem;

    // for debug
    private Quaternion desiredRotation;
    private Quaternion deltaRotationLocal;

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

    public void SetDeltaRotation(Vector3 desiredForwardWorld)
    {
        desiredForwardWorld.Normalize();
        Vector3 desiredForwardLocal = transform.InverseTransformDirection(desiredForwardWorld);
        desiredRotation = Quaternion.LookRotation(desiredForwardLocal);
        desiredRotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, maxRotationDeltaDegrees);
        Quaternion desiredDeltaRotation = desiredRotation * Quaternion.Inverse(transform.rotation);

        deltaRotationLocal = Quaternion.Slerp(deltaRotationLocal, desiredDeltaRotation, steerChangeSlerpFactor);

        steeringSystem.deltaRotationLocal = deltaRotationLocal;
    }

    private void OnDrawGizmos()
    {
        if (drawRotationGizmos) {
            // forward direction
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + 30 * transform.forward);

            // desired forward
            //Gizmos.color = Color.red;
            //Gizmos.DrawLine(transform.position, transform.position + 5 * (desiredRotation * Vector3.forward));

            // forward after deltarotation
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + 20 * (deltaRotationLocal * transform.forward));
        }
        if (drawVisionSpheres && agentFlock != null)
        {
            // draw awareness sphere
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, agentFlock.neighborRadius);
            // draw avoidance sphere
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, agentFlock.neighborRadius * agentFlock.avoidanceRadiusMultiplier);
        }
    }
}
