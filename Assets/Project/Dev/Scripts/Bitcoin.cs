using UnityEngine;
using System;

public class Bitcoin : DamageableObject
{
    public static event Action<Bitcoin> Mining = delegate {  }; 
    
    [SerializeField] 
    private float _angle = 0;
    
    [SerializeField] 
    private float _flightSpeed = 0;

    private Transform _target = null;
    
    void FixedUpdate()
    {
        Rotation();
        
        var finalPos = new Vector3(_target.transform.position.x, 1.5f, _target.transform.position.z);
        float step = Time.deltaTime * _flightSpeed;

        var moveDirection = (finalPos - transform.position).normalized * step;
        transform.position += moveDirection;
    }

    private void Rotation()
    {
        Quaternion rotationZ = Quaternion.AngleAxis(_angle, new Vector3(0, 0, 1));
        transform.rotation *= rotationZ;
    }
    
    public void SetTargetPosition(Transform targetTransform)
    {
        _target = targetTransform;
    } 
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Tower tower))
        {
            OnDie();
        }
    }

    protected override void OnDie()
    {
        base.OnDie();
        Mining(this);
    }
}
