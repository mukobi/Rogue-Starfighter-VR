using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamager
{
    void DoDamage(IDamageable damageable);
}