using UnityEngine.Events;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public LayerMask LayerMask;

    public UnityEvent OnLayeredCollisionEnter;
    public UnityEvent OnLayeredCollisionExit;

    private void OnCollisionEnter(Collision collision)
    {
        if ((LayerMask & 1 << collision.gameObject.layer) != 0)
        {
            OnLayeredCollisionEnter.Invoke();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if ((LayerMask & 1 << collision.gameObject.layer) != 0)
        {
            OnLayeredCollisionExit.Invoke();
        }
    }
}
