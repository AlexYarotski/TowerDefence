using UnityEngine;

public abstract class Life : MonoBehaviour
{
    public float Health
    {
        get;
        set;
    }
    
    public void GetDamage(float damage)
    {
        Health -= damage;
        
        if (Health <= 0)
        {
            OnDie();
        }
    }

    public virtual void OnDie()
    {
        gameObject.SetActive(false);
    }
}
