using System;
using UnityEngine;

[Serializable]
internal class Warhead : Ammunition
{
    [SerializeField]
    private float _speedWarhead = 0;
    
    [SerializeField]
    private float _damageWarhead = 0;
    
    [SerializeField] 
    private Color Color = Color.black;

    [SerializeField]
    private CapsuleCollider _capsuleCollider = null;
    
    private Renderer _renderer = null;
    
    public Warhead(Color color, float speed, float damage)
        : base(speed, damage)
    {
        Color = color;
        speed = _speedWarhead;
        damage = _damageWarhead;
    }
    
    private void Awake()
    {
        _capsuleCollider.isTrigger = true;
        _renderer = GetComponent<Renderer>();
    }
}
