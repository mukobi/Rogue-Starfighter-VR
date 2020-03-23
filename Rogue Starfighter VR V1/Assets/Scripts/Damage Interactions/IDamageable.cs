public interface IDamageable
{
    bool IsDestroyed { get; }

    void TakeDamage(float damage);
}

public interface IDamageableByLaser : IDamageable { }
