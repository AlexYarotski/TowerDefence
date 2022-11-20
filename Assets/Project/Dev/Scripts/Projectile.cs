using System;
using UnityEngine;

[Serializable]
internal class Projectile : Ammunition
{
    [SerializeField]
    private float _speed = 0;
    
    [SerializeField]
    private float _damage = 0;
    
    [SerializeField]
    private CapsuleCollider _capsuleCollider = null;
    
    private Renderer _renderer = null;

    private void Awake()
    {
        _capsuleCollider.isTrigger = true;
        _renderer = GetComponent<Renderer>();
    }
}
