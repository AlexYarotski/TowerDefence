using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tank : DamageableObject
{
    public static event Action<Tank> Dead = delegate { };

    [SerializeField]
    private float _speed = 0;

    [SerializeField]
    private float _damage = 0;

    [SerializeField] private float _tankHeightFromZeroPoint = 0;

    private Transform _target = null;

    private void Start()
    {
        _tankHeightFromZeroPoint = 1.5f;
        StartCoroutine(MovementToTower());
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Tower tower))
        {
            tower.GetDamage(_damage);

            OnDie();
        }
    }

    public void SetTargetPosition(Transform targetTransform)
    {
        _target = targetTransform;

        var rotation = Quaternion.LookRotation((_target.position - transform.position).normalized, Vector3.up).normalized;
        transform.Rotate(0, rotation.eulerAngles.y, 0);
    }
    
    private IEnumerator MovementToTower()
    {
        var finalPos = new Vector3(_target.transform.position.x, _tankHeightFromZeroPoint, _target.transform.position.z);
        
        float currentTime = 0;
        float towerDistance = (finalPos  - transform.position).magnitude;
        float towerMoveTime = towerDistance / _speed;
        var position = transform.position;

        while (currentTime < towerMoveTime)
        {
            float progress = currentTime / towerMoveTime;

            transform.position = Vector3.Lerp(position, finalPos, progress);

            yield return null;

            currentTime += Time.deltaTime;
        }
    }


protected override void OnDie()
    {
        base.OnDie();
        
        Dead(this);
    }
}