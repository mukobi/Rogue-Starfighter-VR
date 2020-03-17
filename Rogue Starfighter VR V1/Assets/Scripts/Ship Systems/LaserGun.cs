using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserGun : Fireable
{
    public UnityEvent fireEvent;
    
    public override void Fire()
    {
        fireEvent.Invoke();
    }
}
