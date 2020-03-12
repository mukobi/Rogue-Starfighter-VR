using UnityEngine.Events;
using UnityEngine;

public class DamageableShipPartWithHealth : MonoBehaviour, IDamageableByLaser
{
    [SerializeField] private float currentHealth = default;
    //[SerializeField] private float maxHealth;

    public UnityEvent OnDestroyed;

    public bool IsDestroyed => (currentHealth <= 0.0f);

    public bool TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (IsDestroyed)
        {
            OnDestroyed.Invoke();
        }
        return IsDestroyed;
    }
}
