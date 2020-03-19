using UnityEngine.Events;
using UnityEngine;

public class DamageableShipPartWithHealth : DamageableShipPart
{
    [SerializeField] private float initialHealth = default;
    private float currentHealth;
    //[SerializeField] private float maxHealth;

    public UnityEventFloat OnHealthChange;
    public UnityEvent OnNoHealth;

    [Tooltip("Should I destroy myself when I run out of health?")]
    [SerializeField] private bool destroyOnNoHealth = false;

    private void Start()
    {
        currentHealth = initialHealth;
        OnHealthChange.Invoke(currentHealth);
    }

    public override bool IsDestroyed => (currentHealth <= 0.0f);

    public override bool TakeDamage(float damage)
    {
        if (!IsDestroyed)
        {
            currentHealth -= damage;
            OnHealthChange.Invoke(currentHealth);
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

    public void SetHealth(float newHealth)
    {
        currentHealth = newHealth;
        OnHealthChange.Invoke(currentHealth);
    }
}
