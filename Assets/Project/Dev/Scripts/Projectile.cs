using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Projectile : Ammunition
{
    [SerializeField]
    private float _speed = 0;
    
    [SerializeField]
    private float _damage = 0;
    
    [SerializeField]
    private CapsuleCollider _capsuleCollider = null;
    
    [SerializeField]
    private Tower _towerPrefab = null;
    
    [SerializeField] 
    private Tank _tankPrefab = null;
    
    private Renderer _renderer = null;

    private void Awake()
    {
        _capsuleCollider.isTrigger = true;
        _renderer = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(_tankPrefab.transform.position, 
            _towerPrefab.transform.position + new Vector3(0.4f, 1.6f),
            Time.deltaTime * _speed);
    }
}