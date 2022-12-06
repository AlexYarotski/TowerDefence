using System;
using UnityEngine;

public class Arrow : Ammunition
{
    private Tank _target = null;

    private void OnEnable()
    {
        Tank.Dead += Check_Target;
    }

    private void OnDisable()
    {
        Tank.Dead -= Check_Target;
    }
    
    private void FixedUpdate()
    {
        float step = Time.deltaTime * _speed;
        
        var moveDirection = (_target.transform.position - transform.position).normalized;
        transform.position += moveDirection * step;
    }
    
    private void Check_Target(Tank target)
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

            OnDie();
        }
    }
    
    public void SetTarget(Tank tank)
    {
      _target = tank;  
    }
}
