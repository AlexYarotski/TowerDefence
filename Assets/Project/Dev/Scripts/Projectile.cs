using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
internal class Projectile : Ammunition
{
    [SerializeField]
    private float _speed = 0;
    
    [SerializeField]
    private float _damage = 0;
    
    [SerializeField]
    private CapsuleCollider _capsuleCollider = null;
    
    [FormerlySerializedAs("_tower")] [SerializeField]
    private Tower _towerPrefab = null;
    
    private Renderer _renderer = null;

    private void Awake()
    {
        _capsuleCollider.isTrigger = true;
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
            _towerPrefab.transform.position + new Vector3(0.4f, 1.6f),
            Time.deltaTime * _speed);
    }
}