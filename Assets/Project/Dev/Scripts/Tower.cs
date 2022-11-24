using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private BoxCollider _collider = null;
    
    [SerializeField]
    private float _health = 0;

    private void Awake()
    {
        _collider.isTrigger = false;
        gameObject.SetActive(true);
    }

    public void HealthLevel(float damage)
    {
        _health -= damage;

        if (_health == 0 || _health < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
