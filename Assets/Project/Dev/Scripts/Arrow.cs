using UnityEngine;

public class Arrow : Ammunition
{
    private Tank _target = null;

    private void OnEnable()
    {
        Tank.Dead += Tanks_Dead;
    }
    
    private void OnDisable()
    {
        Tank.Dead -= Tanks_Dead;
    }
    
    private void FixedUpdate()
    {
        float step = Time.deltaTime * base._speed;
        
        var moveDirection = (_target.transform.position - transform.position).normalized;
        transform.position += moveDirection * step;
    }

    private void Tanks_Dead(Tank obj)
    {
        OnDie();
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
