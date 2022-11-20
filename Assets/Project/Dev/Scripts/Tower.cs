using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private int _helth = 0;

    [SerializeField]
    private float _attackRadius = 0;
    
    [SerializeField] 
    private SphereCollider _sphereCollider = null;

    [SerializeField]
    private Arrow _arrow = null;

    [SerializeField] 
    private Transform _transform = null;

    [SerializeField] 
    private float _shootingSpeed = 0;
    
    [SerializeField] 
    private Tank _tank = null;

    private void Awake()
    {
        _sphereCollider.radius = _attackRadius;
        _sphereCollider.isTrigger = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(_tank.gameObject);
    }
}
