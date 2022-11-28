using UnityEngine;

public delegate int NumKill();

public class Tank : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0;

    [SerializeField] 
    private float _damage = 0;

    [SerializeField]
    private float _health = 0;

    public NumKill numKill = null;
    
    private Transform _target = null;
    private static int _numberKilled = 0;

    private void Awake()
    {
        numKill = GetNumberKilled;
    }

    private void FixedUpdate()
    {
        var finalPos = new Vector3(_target.position.x, 1, _target.position.z);
        float step = Time.deltaTime * _speed;

        var moveDirection = (finalPos - transform.position).normalized * step;
        transform.position += moveDirection;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Tower tower))
        {
            tower.GetDamage(_damage);
            
            OnDie();
        }
    }

    public void SetTargetPosition(Transform targetTransform)
    {
        _target = targetTransform;
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
        _numberKilled++;
    }

    public static int GetNumberKilled() => _numberKilled;
}