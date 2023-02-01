using UnityEngine;
using System;
using System.Collections;

public class Bitcoin : DamageableObject
{                                                         
    private readonly int IsSkale = Animator.StringToHash("IsScale");
    private readonly int IsRotate = Animator.StringToHash("IsRotate");

    public static event Action<Bitcoin> Mining = delegate {  }; 
    
    private float _flightSpeed = 0;
    private Animator _animator = null;
    private Transform _tower = null;
    
    private void Awake()
    {
        var settings = SceneContext.Inctance.BitcoinSettings;
            
        _flightSpeed = settings.FlightSpeed;
        _animator = settings.Animator;
    }
    
    public void SetTargetPosition(Transform targetTransform)
    {
        _tower = targetTransform;

        CoinMovement();
    }

    protected override void OnDie()
    {
        base.OnDie();
        
        Mining(this);
    }

    private IEnumerator MovementToTower()   
    {
        _animator.SetBool(IsRotate, true);
        
        var finalPos = new Vector3(_tower.transform.position.x, 1.5f, _tower.transform.position.z);
        
        float currentTime = 0;
        float towerDistance = (finalPos  - transform.position).magnitude;
        float towerMoveTime = towerDistance / _flightSpeed;
        var position = transform.position;

        while (currentTime < towerMoveTime)
        {
            float progress = currentTime / towerMoveTime;

            transform.position = Vector3.Lerp(position, finalPos, progress);

            yield return null;

            currentTime += Time.deltaTime;
        }
        
        OnDie();
    }

    private void CoinMovement()
    {
        StartCoroutine(MovementToTower());
        
        _animator.SetBool(IsSkale, true);
    }
}
