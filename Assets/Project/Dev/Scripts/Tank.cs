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
    private BoxCollider _boxCollider = null;

    private Renderer _renderer = null;
    
    private void Awake()
    {
        _boxCollider.isTrigger = false;
        _renderer = GetComponent<Renderer>();
    }

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
            bool health = _towerPrefab.HealthLevel(_damage);
            _towerPrefab.gameObject.SetActive(health);
            Destroy(gameObject);
        }
    }
}