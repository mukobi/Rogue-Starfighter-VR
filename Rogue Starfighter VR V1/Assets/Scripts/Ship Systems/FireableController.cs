using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireableController : MonoBehaviour
{

    public Fireable[] fireables;

    public float fireInterval;
    public bool isTryingToFire = false;

    private float lastFireTime;
    private int fireInstantiationPointCurrentIndex = 0;

    private void FixedUpdate()
    {
        if(isTryingToFire)
        {
            if(Time.time - lastFireTime > fireInterval)
            {
                fireables[fireInstantiationPointCurrentIndex].Fire();
                fireInstantiationPointCurrentIndex = (fireInstantiationPointCurrentIndex + 1) % fireables.Length;
                lastFireTime = Time.time;
            }
        }
    }
}
