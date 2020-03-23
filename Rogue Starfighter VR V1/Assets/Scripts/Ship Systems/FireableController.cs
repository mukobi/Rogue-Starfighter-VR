using UnityEngine.Events;
using UnityEngine;

public class FireableController : BasicShipSystemAbstract
{
    public Fireable[] fireables;

    public float fireInterval;
    public bool isTryingToFire = false;

    [SerializeField] private bool isAbleToFire = true;
    public bool IsAbleToFire { get { return isAbleToFire; } set { isAbleToFire = value; } }

    public UnityEvent OnStoppedFiring;

    private bool wasFiringLastTime = false;

    private float lastFireTime;
    private int fireInstantiationPointCurrentIndex = 0;

    private void FixedUpdate()
    {
        if(isTryingToFire && isAbleToFire && !shipSystemIsDisabled)
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
