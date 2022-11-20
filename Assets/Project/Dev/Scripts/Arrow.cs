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

    private Renderer _renderer = null;
    
    private void Awake()
    {
        _boxCollider.isTrigger = true;
        _renderer = GetComponent<Renderer>();
    }
}
