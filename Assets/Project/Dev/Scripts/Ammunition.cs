using UnityEngine;

public abstract class Ammunition : MonoBehaviour
{
    [SerializeField]
    protected float _speed = 0;
    
    [SerializeField] 
    protected float _damage = 0;

    public float Damage
    {
        get => _damage;
    }
    
    protected void OnDie()
    {
        gameObject.SetActive(false);
    }
}
