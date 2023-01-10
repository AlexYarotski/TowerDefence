using System;
using UnityEngine;

public class Arrow : Ammunition
{
    public static Action<bool> _callback = delegate {  };

    private DamageableObject _target = null;
    
    private void OnEnable()
    {
        Tank.Dead += Tank_Dead;
    }

    private void OnDisable()
    {
        Tank.Dead -= Tank_Dead;
    }
    
    private void FixedUpdate()
    {
        float step = Time.deltaTime * _speed;
        
        var moveDirection = (_target.transform.position - transform.position).normalized;
        transform.position += moveDirection * step;
    }
    
    private void Tank_Dead(DamageableObject target)
    {
        if (_target == target || _target == null)
        {
            OnDie();
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out DamageableObject target))
        {
            target.GetDamage(_damage);
            
            _callback.Invoke(target.IsDead);

            OnDie();
        }
    }
    
    public void SetTarget(DamageableObject tank, Action<bool> callback)
    {
      _target = tank;
      _callback = callback;
    }
}
