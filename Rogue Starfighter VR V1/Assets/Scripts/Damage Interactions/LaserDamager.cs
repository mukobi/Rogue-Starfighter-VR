using UnityEngine.Events;
using UnityEngine;

public class LaserDamager : MonoBehaviour, IDamager
{
    public float Damage { get; set; }

    public UnityEvent onDamage;

    public bool DoDamage(IDamageable damageable)
    {
        onDamage.Invoke();
        return damageable.TakeDamage(Damage);
    }

    private void OnCollisionEnter(Collision other)
    {
        var damageableByLaser = other.gameObject.GetComponent<DamageableShipPart>();
        if (damageableByLaser != null)
        {
            DoDamage(damageableByLaser);
            Destroy(gameObject);
        }
    }
}
