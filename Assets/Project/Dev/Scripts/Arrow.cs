using UnityEngine;

public class Arrow : Ammunition
{
    [SerializeField]
    private float _speed = 0;
    
    [SerializeField]
    private float _damage = 0;

    private Tank _target = null;

    private void FixedUpdate()
    {
        var moveDirection = (_target.transform.position - transform.position).normalized;

        transform.position += moveDirection * (_speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Tank tank))
        {
            tank.GetDamage(_damage);
            
            Destroy(gameObject);
        }
    }

    public void SetTarget(Tank tank)
    {
      _target = tank;  
    }
}
