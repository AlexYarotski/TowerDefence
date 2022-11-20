using System;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField]
    private int _helth = 0;

    [SerializeField]
    private float _speed = 0;
    
    [SerializeField]
    private BoxCollider _boxCollider = null;
    
    [SerializeField] 
    private Projectile _projectile = null;

    [SerializeField]
    private Tower _tower = null;

    [SerializeField]
    private Projectile _projectilePrefab = null;
    
    private Renderer _renderer = null;
    
    private void Awake()
    {
        _boxCollider.isTrigger = true;
        _renderer = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        float step = Time.deltaTime * _speed;
        transform.position = Vector3.MoveTowards(transform.position, 
            _tower.transform.position + new Vector3(0.4f, 1.6f), step);
    }

    
}