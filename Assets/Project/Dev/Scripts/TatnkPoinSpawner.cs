using System;
using Project.Dev.Scripts;
using UnityEngine;

public class TatnkPoinSpawner : MonoBehaviour
{
    public static event Action<Tank> Spawned = delegate { };
    
    [SerializeField]
    private LayerMask _layerMask = default;
    
    [SerializeField]
    private Camera _camera = null;

    [SerializeField] 
    private PoolManager _poolManager = null;

    [SerializeField]
    private Tank _tank = null;
    
    [SerializeField]
    private Weapon _weapon = null;

    private PooledType _pooledType = default;

    private void Awake()
    {
        _pooledType = PooledType.Tank;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, Int32.MaxValue, _layerMask))
            {
                Vector3 startPosition = new Vector3(hitInfo.point.x, 1.5f, hitInfo.point.z);

                //Tank createTank = Instantiate(_tank, startPosition, Quaternion.identity, transform);

                var createTank = _poolManager.GetObject<Tank>(_pooledType, startPosition);
                
                Spawned(createTank);
                
                createTank.SetTargetPosition(_weapon.transform);
            }
        }
    }
}