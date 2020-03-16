using UnityEngine.Events;
using UnityEngine;

public class DamageableShipPartWithHealth : DamageableShipPart
{
    [SerializeField] private float currentHealth = default;
    //[SerializeField] private float maxHealth;

    public UnityEvent OnNoHealth;

    [Tooltip("Should I destroy myself when I run out of health?")]
    [SerializeField] private bool destroyOnNoHealth = false;

    public override bool IsDestroyed => (currentHealth <= 0.0f);

    public override bool TakeDamage(float damage)
    {
        if (!IsDestroyed)
        {
            currentHealth -= damage;
            if (IsDestroyed)
            {
                OnNoHealth.Invoke();
                if (destroyOnNoHealth)
                {
                    Destroy(gameObject);
                }
            }
        }
        return IsDestroyed;
    }
}
