using System;
using UnityEngine;

public class Tank : DamageableObject
{
    public static event Action<Tank> Dead = delegate {  }; 

    [SerializeField]
    private float _speed = 0;

    [SerializeField] 
    private float _damage = 0;

    private Transform _target = null;

    private void FixedUpdate()
    {
        var finalPos = new Vector3(_target.transform.position.x, 1, _target.transform.position.z);
        float step = Time.deltaTime * _speed;

        var moveDirection = (finalPos - transform.position).normalized * step;
        transform.position += moveDirection;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Tower tower))
        {
            tower.GetDamage(_damage);
            
            OnDie();
        }
    }
    
    public void SetTargetPosition(Transform targetTransform)
     {
         _target = targetTransform;
     } 

    protected override void OnDie()
    {
        base.OnDie();
        Dead(this);
    }
}