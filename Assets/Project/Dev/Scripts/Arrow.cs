using System;
using System.Collections;
using Project.Dev.Scripts;
using UnityEngine;

public class Arrow : Ammunition
{
    private DamageableObject _target = null;

    private void Awake()
    {
        var settings = SceneContext.Inctance.ArrowSettings;

        _damage = settings.Damage;
        _speed = settings.Speed;
    }

    private void OnEnable()
    {
        Tank.Dead += Tank_Dead;
    }

    private void OnDisable()
    {
        Tank.Dead -= Tank_Dead;
    }

    public void SetTarget(DamageableObject tank)
    {
        _target = tank;
        
        StartCoroutine(MovementToTarget());
    }
    
    private void Tank_Dead(DamageableObject target)
    {
        if (_target == target || _target == null)
        {
            OnDie();
        }
    }
    
    private IEnumerator MovementToTarget()
    {
        var finalPos = _target.transform.position;
        var position = transform.position;
        
        float currentTime = 0;
        float towerDistance = (finalPos - transform.position).magnitude;
        float towerMoveTime = towerDistance / _speed;
        
        while (currentTime < towerMoveTime)
        {
            float progress = currentTime / towerMoveTime;

            transform.position = Vector3.Lerp(position, _target.transform.position, progress);

            yield return null;

            currentTime += Time.deltaTime;
        }

        Damage();
    }

    private void Damage()
    {
        _target.GetDamage(_damage);

        OnDie();
    }
}
