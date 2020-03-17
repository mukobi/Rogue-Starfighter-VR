using UnityEngine.Events;
using UnityEngine;

public class FireableController : MonoBehaviour
{

    public Fireable[] fireables;

    public float fireInterval;
    public bool isTryingToFire = false;

    public UnityEvent OnStoppedFiring;

    private bool wasFiringLastTime = false;

    private float lastFireTime;
    private int fireInstantiationPointCurrentIndex = 0;

    private void FixedUpdate()
    {
        if(isTryingToFire)
        {
            if(Time.time - lastFireTime > fireInterval)
            {
                // can fire
                fireables[fireInstantiationPointCurrentIndex].Fire();
                fireInstantiationPointCurrentIndex = (fireInstantiationPointCurrentIndex + 1) % fireables.Length;
                lastFireTime = Time.time;
                wasFiringLastTime = true;
            }
        }
        else
        {
            if (wasFiringLastTime)
            {
                OnStoppedFiring.Invoke();
                wasFiringLastTime = false;
            }
        }
    }
}
