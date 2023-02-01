using System;
using Project.Dev.Scripts;
using UnityEngine;

public class Tower : DamageableObject
{
    public static event Action<Tower> Dead = delegate { };

    private Transform _target = null;

    private void Awake()
    {
        var settings = SceneContext.Inctance.TowerSettings;
        
        _health = settings.Health;
    }

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
        var vector = transform.position - _target.position;
        var rotation = new Vector3(vector.x, 0, vector.z);
        var finalRotation = Quaternion.LookRotation(rotation.normalized, Vector3.up)
            .normalized;
        
        transform.rotation = finalRotation;
    }
}