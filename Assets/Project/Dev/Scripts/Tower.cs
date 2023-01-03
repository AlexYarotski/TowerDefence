using System;
using UnityEngine;

public class Tower : DamageableObject
{
    public static event Action<Tower> Dead = delegate { };
    
    [SerializeField]
    private float _speed = 0;

    private Transform _target = null;

    private void OnEnable()
    {
        Weapon.ShotTank += Shot_Tank;
    }

    private void OnDisable()
    {
        Weapon.ShotTank -= Shot_Tank;
    }

    private void Shot_Tank(Tank tank)
    {
        SetTargetPosition(tank.transform);
    }
    
    public void SetTargetPosition(Transform targetTransform)
    {
        var _target = targetTransform;

        var rotation = Quaternion.LookRotation((_target.position - transform.position).normalized, 
            Vector3.up).normalized;
        transform.rotation = rotation;
    }

    protected override void OnDie()
    {
        base.OnDie();
        
        Dead(this);
    }
}