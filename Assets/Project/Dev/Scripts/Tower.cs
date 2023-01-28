using System;
using Project.Dev.Scripts;
using UnityEngine;

public class Tower : DamageableObject
{
    public static event Action<Tower> Dead = delegate { };

    private Transform _target = null;

    private void OnEnable()
    {
        Weapon.ShotTank += Weapon_ShotTank;
    }

    private void OnDisable()
    {
        Weapon.ShotTank -= Weapon_ShotTank;
    }
    
    protected override void OnDie()
    {
        base.OnDie();
        
        Dead(this);
    }
    
    private void Weapon_ShotTank(DamageableObject tank)
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
}