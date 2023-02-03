public abstract class Ammunition : PooledBehaviour
{
    protected float _speed = 0;
    protected float _damage = 0;

    protected void OnDie()
    {
        gameObject.SetActive(false);
    }
}
