using System;
using UnityEngine;

public class Tower : DamageableObject
{
    public static event Action<Tower> Dead = delegate { };

    [SerializeField] 
    private Weapon _weapon = null;

    private Transform _target = null;

    private void OnEnable()
    {
        Weapon.ShotTank += Shot_Tank;
    }

    private void OnDisable()
    {
        Weapon.ShotTank -= Shot_Tank;
    }
    
    protected override void OnDie()
    {
        base.OnDie();
        
        Dead(this);
    }
    
    private void Shot_Tank(DamageableObject tank)
    {
        _target = tank.transform;
        SetTargetPosition();
    }

    private void SetTargetPosition()
    {
        var rotation = Quaternion.LookRotation((transform.position - _target.position).normalized, Vector3.up)
            .normalized;
        transform.rotation = rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out DamageableObject target))
        {
            var zeroPointRotation = Quaternion.Euler(0, transform.rotation.y, 0);
            transform.rotation =  zeroPointRotation;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _weapon.GetRadius());
    }
}