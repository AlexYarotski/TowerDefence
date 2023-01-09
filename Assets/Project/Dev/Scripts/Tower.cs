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
        SetTargetPosition(tank.transform);
    }
    
    public void SetTargetPosition(Transform targetTransform)
    {
        _target = targetTransform;
        var rotation = Quaternion.LookRotation((transform.position - _target.position).normalized, 
            Vector3.up).normalized;
        
        transform.Rotate(0, rotation.eulerAngles.y, 0);
    }

    protected override void OnDie()
    {
        base.OnDie();
        
        Dead(this);
    }
}