using System;
using UnityEngine;

[Serializable]
public class Arrow : Ammunition
{
    [SerializeField]
    private float _speed = 0;
    
    [SerializeField]
    private float _damage = 0;
    
    [SerializeField]
    private BoxCollider _boxCollider = null;

    [SerializeField] 
    private Tank _tankPrefab = null;
    
    
    private Renderer _renderer = null;

    private void OnEnable()
    {
        Tank.DamageTank += TankPrefab;
    }

    private void OnDisable()
    {
        Tank.DamageTank -= TankPrefab;
    }

    private void Awake()
    {
        _boxCollider.isTrigger = false;
        _renderer = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        float step = Time.deltaTime * _speed;
        transform.position = Vector3.MoveTowards(transform.position, _tankPrefab.transform.position, step);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Tank tank))
        {
            HelthTank();
            
            Destroy(gameObject);
        }
    }
    
    private void TankPrefab(Tank tank)
    {
        _tankPrefab = tank;
    }
    
    private void HelthTank()
    {
        bool hasLifeTank = _tankPrefab.GetDamage(_damage);
        _tankPrefab.gameObject.SetActive(hasLifeTank);
    }
}
