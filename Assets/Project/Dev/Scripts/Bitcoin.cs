using UnityEngine;
using System;
using System.Collections;

public class Bitcoin : DamageableObject
{
    private readonly int IsRotate = Animator.StringToHash("IsRotate");
    
    public static event Action<Bitcoin> Mining = delegate {  }; 
    
    [SerializeField] 
    private float _flightSpeed = 0;

    [SerializeField] 
    private Animator _animator = null;

    private Transform _tower = null;

    private void Start()
    {
        StartCoroutine(MovementToTower());
        _animator.SetBool(IsRotate, true);
    }

    public void SetTargetPosition(Transform targetTransform)
    {
        _tower = targetTransform;
    }

    protected override void OnDie()
    {
        base.OnDie();
        Mining(this);
    }

    private IEnumerator MovementToTower()
    {
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
}
