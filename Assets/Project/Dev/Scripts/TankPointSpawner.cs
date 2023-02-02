using System;
using UnityEngine;

namespace Project.Dev.Scripts
{
    public class TankPointSpawner : MonoBehaviour
    {
        public static event Action<Tank> Spawned = delegate { };
    
        [SerializeField]
        private LayerMask _layerMask = default;
    
        [SerializeField]
        private Camera _camera = null;

        [SerializeField]
        private Tower _tower = null;

        [SerializeField] 
        private PoolManager _poolManager = null;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hitInfo, Int32.MaxValue, _layerMask))
                {
                    Vector3 startPosition = new Vector3(hitInfo.point.x, 1.5f, hitInfo.point.z);
                
                    var createTank = _poolManager.GetObject<Tank>(PooledType.Tank, startPosition);

                    Spawned(createTank);
                
                    createTank.SetTargetPosition(_tower);
                }
            }
        }
    }
}