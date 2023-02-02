public abstract class DamageableObject : PooledBehaviour
{
    protected float _health = 0;

    public bool IsDead
    {
        get => _health <= 0;
    }

    public void GetDamage(float damage)
    {
        _health -= damage;
        
        if (_health <= 0)
        {
            OnDie();
        }
    }

    protected virtual void OnDie()
    {
        Free();
    }
}