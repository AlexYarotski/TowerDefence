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
        var rotation = (transform.position - _target.position).normalized; 
        transform.rotation = Quaternion.LookRotation(rotation,Vector3.up);
    }
  
    protected override void OnDie()
    {
        base.OnDie();
        
        Dead(this);
    }
}