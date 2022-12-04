using UnityEngine;

public abstract class DamageableObject : MonoBehaviour
{
    [SerializeField]
    private float _health = 0;
    
    public void GetDamage(float damage)
    {
        _health -= damage;
        
        if (_health <= 0)
        {
            OnDie();
        }
    }

    protected virtual void OnDie()
    {
        gameObject.SetActive(false);
    }
}
