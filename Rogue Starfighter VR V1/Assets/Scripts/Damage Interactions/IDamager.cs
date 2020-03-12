using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamager
{
    bool Damage(IDamageable damageable);
}