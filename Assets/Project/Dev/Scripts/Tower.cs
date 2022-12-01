using UnityEngine;

public class Tower : Life
{
    [SerializeField]
    private float _health = 0;

    public void GetDamage(float damage)
    {
        Health = _health;
        
        base.GetDamage(damage);

        _health = Health;
    }
    
    public override sealed void OnDie()
    {
        gameObject.SetActive(false);
    }
}
