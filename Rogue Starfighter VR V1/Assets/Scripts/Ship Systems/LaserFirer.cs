using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFirer : MonoBehaviour
{

    public LaserGun[] laserGuns;

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
                laserGuns[fireInstantiationPointCurrentIndex].Fire();
                fireInstantiationPointCurrentIndex = (fireInstantiationPointCurrentIndex + 1) % laserGuns.Length;
                lastFireTime = Time.time;
            }
        }
    }
}
