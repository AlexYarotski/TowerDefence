using UnityEngine;

public class Tower : Life
{
    [SerializeField]
    private float _health = 0;

    public override void GetDamage(float damage)
    {
        Health = _health;
        
        base.GetDamage(damage);

        _health = Health;
    }
}
