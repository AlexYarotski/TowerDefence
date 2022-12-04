using UnityEngine;

public abstract class Ammunition : MonoBehaviour
{
    public float Speed
    {
        get;
        private set;
    }

    public float Damage
    {
        get;
        private set;
    }
    
    public void OnDie()
    {
        gameObject.SetActive(false);
    }
}
