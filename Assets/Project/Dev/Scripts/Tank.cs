using System;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public static event Action<Tank> Dead = delegate {  }; 

    [SerializeField]
    private float _speed = 0;

    [SerializeField] 
    private float _damage = 0;

    [SerializeField]
    private float _health = 0;

    [SerializeField] 
    private Tower _tower = null;

    private Transform _target = null;


    private void Start()
    {
        CheckTarget();
    }

    private void FixedUpdate()
    {
        var finalPos = new Vector3(_target.transform.position.x, 1, _target.transform.position.z);
        float step = Time.deltaTime * _speed;

        var moveDirection = (finalPos - transform.position).normalized * step;
        transform.position += moveDirection;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Tower tower))
        {
            tower.GetDamage(_damage);
            
            OnDie();
        }
    }

    private void CheckTarget()
    {
        if (_target == null)
        {
            _target = _tower.transform;
        }
    }
    
    public void SetTargetPosition(Transform targetTransform)
     {
         _target = targetTransform;
     } 
    
    public void GetDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            OnDie();
        }
    }

    private void OnDie()
    {
        gameObject.SetActive(false);
        Dead(this);
    }
}