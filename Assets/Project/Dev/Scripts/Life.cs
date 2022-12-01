using UnityEngine;

public abstract class Life : MonoBehaviour
{
    public float Health
    {
        get;
        set;
    }
    
    public virtual void GetDamage(float damage)
    {
        Health -= damage;
        
        if (Health <= 0)
        {
            OnDie();
        }
    }

    protected void OnDie()
    {
        gameObject.SetActive(false);
    }
}
