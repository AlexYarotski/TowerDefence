using UnityEngine;
using System;

[RequireComponent(typeof(SphereCollider))]
public class Weapon : MonoBehaviour
{
    public static event Action<DamageableObject> ShotTank = delegate { };

    [SerializeField] 
    private float _attackRadius = 0;

    [SerializeField] 
    private float _speedAtack = 0;
    
    [SerializeField]
    private Arrow _arrowPrefab = null;

    [SerializeField] 
    private TargetFinder _targetFinder = null;

    [SerializeField] 
    private Transform _arrowSpawnPoint = null;

    [SerializeField] 
    private Animator _animator = null;

    private SphereCollider _sphereCollider = null;
    private DamageableObject _target = null;

    public float GetRadius()
    {
        return _attackRadius;
    }

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.radius = _attackRadius;

        _animator.speed = _speedAtack;
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

    private void Tank_Dead(Tank tank)
    {
        _animator.SetBool("IsShot", false);
    }

    private bool CanShot()
    {
        if (_targetFinder.HasTank())
        {
            var radius = new Vector3(_attackRadius, 0, _attackRadius);

            float distation = (transform.position + radius).sqrMagnitude;
            float targetPosition = (_targetFinder.SearchNearestTank().transform.position).sqrMagnitude;

            if (targetPosition <= distation)
            {
                return true;
            }
        }
        
        return false;
    }

    public void Shot()
    {
        if (CanShot())
        {
            if (_target == null || _target.IsDead)
            {
                _target = _targetFinder.SearchNearestTank();

                ShotTank(_target);

                _animator.SetBool("IsShot", true);
            }
            
        }
    }

    public void Fire(DamageableObject tank)
    {
        Arrow createdArrow = Instantiate(_arrowPrefab, _arrowSpawnPoint.position, Quaternion.identity, transform);

        createdArrow.SetTarget(tank, isTankDead =>
        {
            if (isTankDead)
            {
                return;
            }
        });
    }
}