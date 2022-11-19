using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField]
    private int _helth = 0;

    [SerializeField]
    private float _speed = 0;
    
    [SerializeField]
    private BoxCollider _boxCollider = null;

    [SerializeField] 
    private Warhead _warhead = null;

    [SerializeField]
    private Tower _tower = null;
    
    private Renderer _renderer = null;
    
    private void Awake()
    {
        _boxCollider.isTrigger = true;
        _renderer = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        transform.position += _tower.transform.position * _speed;
    }
}
