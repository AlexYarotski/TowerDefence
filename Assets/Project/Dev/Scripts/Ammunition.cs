using UnityEngine;

public abstract class Ammunition : MonoBehaviour
{
    [SerializeField]
    protected float _speed = 0;
    
    [SerializeField] 
    protected float _damage = 0;

    public float damage = 0;
    
    protected void OnDie()
    {
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        damage = _damage;
    }
}
