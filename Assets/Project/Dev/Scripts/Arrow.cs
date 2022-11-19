using System;
using UnityEngine;

[Serializable]
internal class Arrow : Ammunition
{
    [SerializeField]
    private float _speedArrow = 0;
    
    [SerializeField]
    private float _damageArrow = 0;
    
    [SerializeField] 
    private Color Color = Color.green;
    
    [SerializeField]
    private BoxCollider _boxCollider = null;

    public Arrow(Color color, float speed, float damage)
        : base(speed, damage)
    {
        Color = color;
        speed = _speedArrow;
        damage = _damageArrow;
    }

    private void Awake()
    {
        _boxCollider.isTrigger = true;
    }
}
