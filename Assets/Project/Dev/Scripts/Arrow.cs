using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
internal class Arrow : Ammunition
{
    [SerializeField]
    private float _speed = 0;
    
    [SerializeField]
    private float _damage = 0;
    
    [SerializeField]
    private BoxCollider _boxCollider = null;

    [SerializeField] 
    private Tank _tankPrefab = null;

    [SerializeField] 
    private Tower _towerPrefab = null;
    
    private Renderer _renderer = null;
    
    private void Awake()
    {
        _boxCollider.isTrigger = true;
        _renderer = GetComponent<Renderer>();
    }
    
    private void FixedUpdate()
    {
        float step = Time.deltaTime * _speed;
        transform.position = Vector3.MoveTowards(_towerPrefab.transform.position, 
            _tankPrefab.transform.position + new Vector3(0.2f, 0.8f), step);
    }
}
