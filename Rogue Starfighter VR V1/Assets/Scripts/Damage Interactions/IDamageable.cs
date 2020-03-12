public interface IDamageable
{
    bool IsDestroyed { get; }

    bool TakeDamage(float damage);
}

public interface IDamageableByLaser : IDamageable { }
