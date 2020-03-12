using UnityEngine.Events;
using UnityEngine;

public class DamageableShipPart : MonoBehaviour, IDamageableByLaser
{
    public virtual bool IsDestroyed => false; // can never be destroyed

    public virtual bool TakeDamage(float damage)
    {
        return IsDestroyed;
    }
}
