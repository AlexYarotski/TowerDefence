using UnityEngine;

public class Tower : MonoBehaviour
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
    
    private void OnDie()
    {
        gameObject.SetActive(false);
    }
}
