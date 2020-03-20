using UnityEngine.Events;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public LayerMask LayerMask;

    public UnityEvent WhenTriggerEnter;
    public UnityEvent WhenTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if ((LayerMask & 1 << other.gameObject.layer) != 0)
        {
            WhenTriggerEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((LayerMask & 1 << other.gameObject.layer) != 0)
        {
            WhenTriggerExit.Invoke();
        }
    }
}
