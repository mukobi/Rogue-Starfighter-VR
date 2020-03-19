using UnityEngine.Events;
using UnityEngine;

public class DamageableShipPartWithHealth : DamageableShipPart
{
    [SerializeField] private float minHealth = default;
    [SerializeField] private float maxHealth = default;
    [SerializeField] private float initialHealth = default;
    private float currentHealth;
    //[SerializeField] private float maxHealth;

    public UnityEventFloat OnHealthChange;
    public UnityEventFloat OnHealthLose;
    public UnityEventFloat OnHealthGain;
    public UnityEvent OnNoHealth;

    [Tooltip("Should I destroy myself when I run out of health?")]
    [SerializeField] private bool destroyOnNoHealth = false;

    // TODO: try compare to minHealth + smallEpsilon if encountering float comparison bug
    public override bool IsDestroyed => (currentHealth <= minHealth);

    private void Start()
    {
        SetHealth(initialHealth);
    }

    public override bool TakeDamage(float amount)
    {
        OnHealthLose.Invoke(amount);
        return SetHealth(currentHealth - amount);
    }

    public bool GainHealth(float amount)
    {
        OnHealthGain.Invoke(amount);
        return SetHealth(currentHealth + amount);
    }

    public bool SetHealth(float newHealth)
    {
        newHealth = Mathf.Clamp(newHealth, minHealth, maxHealth);
        currentHealth = newHealth;
        OnHealthChange.Invoke(currentHealth);
        if (IsDestroyed)
        {
            OnNoHealth.Invoke();
            if (destroyOnNoHealth)
            {
                Destroy(gameObject);
            }
        }
        return IsDestroyed;
    }
}
