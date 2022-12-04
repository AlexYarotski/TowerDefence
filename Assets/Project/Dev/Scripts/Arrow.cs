using UnityEngine;

public class Arrow : Ammunition
{
    [SerializeField]
    private float _speed = 0;
    
    [SerializeField]
    private float _damage = 0;

    private Tank _target = null;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Tank tank))
        {
            tank.GetDamage(_damage);

            OnDie();
        }
    }
    
    private void Tank_Dead(Tank obj)
    {
        OnDie();
    }

    public void SetTarget(Tank tank)
    {
      _target = tank;  
    }
}
