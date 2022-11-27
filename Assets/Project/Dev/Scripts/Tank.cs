using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0;

    [SerializeField]
    private Tower _towerPrefab = null;

    [SerializeField] 
    private float _damage = 0;

    [SerializeField]
    private float _health = 3;

    private void FixedUpdate()
    {
        float step = Time.deltaTime * _speed;
        transform.position = Vector3.MoveTowards(transform.position, 
            _towerPrefab.transform.position + new Vector3(0.2f, 1), step);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Tower tower))
        {
            tower.GetDamage(_damage);
            
            OnDie();
        }
    }
    
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