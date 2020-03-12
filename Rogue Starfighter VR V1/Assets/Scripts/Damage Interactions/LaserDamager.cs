using UnityEngine.Events;
using UnityEngine;

public class LaserDamager : MonoBehaviour, IDamager
{
    [SerializeField] private float damage = default;

    public UnityEvent onDamage;

    public bool Damage(IDamageable damageable)
    {
        onDamage.Invoke();
        return damageable.TakeDamage(damage);
    }

    private void OnCollisionEnter(Collision other)
    {
        var damageableByLaser = other.gameObject.GetComponent<IDamageableByLaser>();
        if (damageableByLaser != null)
        {
            Damage(damageableByLaser);
            Destroy(gameObject);
        }
    }
}
