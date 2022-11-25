using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private float _health = 0;

    private void Awake()
    {
        gameObject.SetActive(true);
    }

    public void GetDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
