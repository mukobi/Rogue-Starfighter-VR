using UnityEngine.Events;
using UnityEngine;

public class DamageableShipPartNoHealth : MonoBehaviour, IDamageableByLaser
{
    public bool IsDestroyed => false; // can never be destroyed

    public bool TakeDamage(float damage)
    {
        return IsDestroyed;
    }
}
