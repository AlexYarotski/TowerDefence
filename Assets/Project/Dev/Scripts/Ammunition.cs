using UnityEngine;

public abstract class Ammunition : PooledBehaviour
{
    [SerializeField]
    protected float _speed = 0;
    
    [SerializeField] 
    protected float _damage = 0;

    protected void OnDie()
    {
        gameObject.SetActive(false);
    }
}
