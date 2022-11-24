using System;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public static event Action<Tank> DamageTank = delegate { };

    [SerializeField]
    private float _speed = 0;

    [SerializeField]
    private Tower _towerPrefab = null;

    [SerializeField] 
    private float _damage = 0;

    [SerializeField]
    private BoxCollider _boxCollider = null;
    
    [SerializeField]
    private float _health = 3;
    
    private Renderer _renderer = null;
    
    private void Awake()
    {
        _boxCollider.isTrigger = false;
        _renderer = GetComponent<Renderer>();
        DamageTank(this);
    }

    private void FixedUpdate()
    {
        float step = Time.deltaTime * _speed;
        transform.position = Vector3.MoveTowards(transform.position, 
            _towerPrefab.transform.position + new Vector3(0.2f, 1), step);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Tower tower))
        {
            _towerPrefab.HealthLevel(_damage);
            
            gameObject.SetActive(false);
        }
    }
    
    public bool HealthLevel(float damage)
    {
        _health -= damage;

        return _health == 0 || _health < 0;
    }
}