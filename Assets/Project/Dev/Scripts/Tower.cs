using System;
using UnityEngine;

public class Tower : DamageableObject
{
    public static event Action<Tower> Dead = delegate { };

    private Transform _target = null;

    private void OnEnable()
    {
        Weapon.ShotTank += Shot_Tank;
    }

    private void OnDisable()
    {
        Weapon.ShotTank -= Shot_Tank;
    }

    private void Shot_Tank(DamageableObject tank)
    {
        _target = tank.transform;
        SetTargetPosition();
    }

    private void SetTargetPosition()
    {
        var rotation = Quaternion.LookRotation((_target.position - transform.position).normalized, Vector3.up)
            .normalized;
        transform.rotation = rotation;
    }
  
    protected override void OnDie()
    {
        base.OnDie();
        
        Dead(this);
    }
}