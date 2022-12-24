using System;
using UnityEngine;

public class Arrow : Ammunition
{
    public static Action<bool> _callback = delegate {  };

    private DamageableObject _target = null;
    private bool _isDeadTank = false;
    
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
    
    private void Tank_Dead(Tank target)
    {
        if (_target == target)
        {
            OnDie();
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Tank tank))
        {
            tank.GetDamage(_damage);
            
            _callback.Invoke(tank.IsDead);

            OnDie();
        }
    }
    
    public void SetTarget(Tank tank, Action<bool> callback)
    {
      _target = tank;
      _callback = callback;
    }
}
