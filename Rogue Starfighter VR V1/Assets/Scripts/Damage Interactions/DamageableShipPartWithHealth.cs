using UnityEngine.Events;
using UnityEngine;

public class DamageableShipPartWithHealth : DamageableShipPart
{
    [SerializeField] private float currentHealth = default;
    //[SerializeField] private float maxHealth;

    public UnityEvent OnDestroyed;

    public override bool IsDestroyed => (currentHealth <= 0.0f);

    public override bool TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (IsDestroyed)
        {
            OnDestroyed.Invoke();
        }
        return IsDestroyed;
    }
}
