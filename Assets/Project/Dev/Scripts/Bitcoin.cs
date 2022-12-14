using UnityEngine;
using System;
using System.Collections;

public class Bitcoin : DamageableObject
{
    public static event Action<Bitcoin> Mining = delegate {  }; 
    
    [SerializeField] 
    private float _angle = 0;
    
    [SerializeField] 
    private float _flightSpeed = 0;

    private Transform _tower = null;

    private void Start()
    {
        StartCoroutine(MovementToTower());
    }

    private void Rotation()
    {
        Quaternion rotationZ = Quaternion.AngleAxis(_angle, new Vector3(0, 0, 1));
        transform.rotation *= rotationZ;
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
            Rotation();

            float progress = currentTime / towerMoveTime;

            transform.position = Vector3.Lerp(position, finalPos, progress);

            yield return null;

            currentTime += Time.deltaTime;
        }
        
        OnDie();
    }
}
