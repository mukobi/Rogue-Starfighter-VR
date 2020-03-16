using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(GenericSteeringSystem))]
[RequireComponent(typeof(PlayerRelativeTransformCalculator))]
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
    private GenericSteeringSystem steeringSystem;
    
    // player reference
    public PlayerRelativeTransformCalculator PlayerRelative { get; private set; }

    // for debug
    Vector3 desiredForwardWorld;
    Vector3 desiredForwardLocal;
    private Quaternion desiredOrientationWorld;
    private Quaternion desiredOrientationLocal;
    private Quaternion desiredDeltaRotationLocal;
    private Quaternion deltaRotationLocal;

    private readonly bool drawVisionSpheres = false;
    private readonly bool drawRotationGizmos = true;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        agentCollider = GetComponent<Collider>();
        steeringSystem = GetComponent<GenericSteeringSystem>();
        PlayerRelative = GetComponent<PlayerRelativeTransformCalculator>();
    }

    public void Initialize(BoidFlock flock)
    {
        agentFlock = flock;
    }

    public void SetDeltaRotation(Vector3 desiredForwardWorldIn)
    {
        // normalize desired forward vector in local space
        desiredForwardWorld = desiredForwardWorldIn;
        desiredForwardWorld.Normalize();

        //desiredForwardLocal = transform.InverseTransformDirection(desiredForwardWorld);
        //desiredForwardLocal.Normalize();

        // compute rotation pointing at desired forward vector
        desiredOrientationWorld = Quaternion.LookRotation(desiredForwardWorld);

        // clamp to maxRotationDeltaDegrees away from current rotation
        desiredOrientationWorld = Quaternion.RotateTowards(transform.rotation, desiredOrientationWorld, maxRotationDeltaDegrees);

        // compute desired orientation in local space
        desiredOrientationLocal = Quaternion.Inverse(transform.parent.rotation) * desiredOrientationWorld;

        // compute rotation that gets us from current rotation to desired local rotation
        desiredDeltaRotationLocal = desiredOrientationLocal * Quaternion.Inverse(transform.localRotation);

        // spherically interpolate previous ▲rotation to desired ▲rotation (smoothes the steering)
        deltaRotationLocal = Quaternion.Slerp(deltaRotationLocal, desiredDeltaRotationLocal, steerChangeSlerpFactor);

        // apply steering to the SteeringSystem component (i.e. steer the ship)
        steeringSystem.deltaRotationLocal = deltaRotationLocal;
    }

    private void OnDrawGizmos()
    {
        if (drawRotationGizmos) {
            // forward direction
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + 30 * transform.forward);

            //Gizmos.color = Color.yellow;
            //Gizmos.DrawLine(transform.position, transform.position + 25 * (desiredForwardWorld));
        }
    }

    private void OnDrawGizmosSelected()
    { 
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
