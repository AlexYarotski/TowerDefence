using System;
using UnityEngine;

namespace Project.Dev.Scripts
{
    public class Weapon : MonoBehaviour
    {
        private readonly int IsShot = Animator.StringToHash("IsShot");
    
        public static event Action<DamageableObject> ShotTank = delegate { };

        [SerializeField]
        private Arrow _arrowPrefab = null;
        
        [SerializeField] 
        private float _attackRadius = 0;

        [SerializeField] 
        private float _speedAtack = 0;
    
        [SerializeField] 
        private TargetFinder _targetFinder = null;

        [SerializeField] 
        private Transform _arrowSpawnPoint = null;

        [SerializeField] 
        private Animator _animator = null;

        [SerializeField]
        private PoolManager _poolManager = null;

        private DamageableObject _target = null;
        private PooledType _pooledType = PooledType.Arrow;
    
        private void Awake()
        {
            _animator.speed = _speedAtack;
            _pooledType = PooledType.Arrow;
        }

        private void OnEnable()
        {
            Tank.Dead += Tank_Dead;
        }

        private void OnDisable()
        {
            Tank.Dead -= Tank_Dead;
        }

        private void FixedUpdate()
        {
            Shot();
        }
    
        public float GetRadius()
        {
            return _attackRadius;
        }

        public void Fire(DamageableObject tank)
        {
            Arrow createdArrow = Instantiate(_arrowPrefab, _arrowSpawnPoint.position, Quaternion.identity, transform);
            //var createdArrow = _poolManager.GetObject<Arrow>(_pooledType, _arrowSpawnPoint.position);
        
            createdArrow.SetTarget(tank);
        }
    
        private void Tank_Dead(Tank tank)
        {
            _animator.SetBool(IsShot, false);

            if (_target == tank)
            {
                _target = null;
            }
        }

        private void Shot()
        {
            if (_targetFinder.CanShot())
            {
                if (_target == null || _target.IsDead)
                {
                    _target = _targetFinder.SearchNearestTank();

                    ShotTank(_target);

                    _animator.SetBool(IsShot, true);
                }
            
            }
        }
    
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Mathf.Sqrt(_attackRadius));
        }
    }
}