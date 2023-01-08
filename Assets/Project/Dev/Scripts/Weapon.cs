using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float _attackRadius = 0;

    [SerializeField] 
    private float _firingDelay = 0;

    [SerializeField] 
    private int _numberShellsPerTank = 0;
    
    [SerializeField]
    private Arrow _arrowPrefab = null;

    [SerializeField]
    private TargetFinder _targetFinder = null;

    [SerializeField]
    private Transform _arrowSpawnPoint = null;

    [SerializeField]
    private Animator _animator = null;
    
    private SphereCollider _sphereCollider = null;
    private List<DamageableObject> targetList = new List<DamageableObject>();
    private Coroutine _fire = null;

    public float GetRadius()
    {
        return _attackRadius;
    }

    public List<DamageableObject> GetTarget()
    {
        return targetList;
    }

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        
        _sphereCollider.radius = _attackRadius;
    }
    
    private void OnEnable()
    {
        SpawnPointTank.Spawn += Spawn_Tank;
        Tank.Dead += Tank_Dead;
    }

    private void OnDisable()
    {
        SpawnPointTank.Spawn -= Spawn_Tank;
        Tank.Dead -= Tank_Dead;
    }
    
    private void FixedUpdate()
    {
        _targetFinder.Shot();
    }
    
    private void Spawn_Tank(Tank tank)
    {
        targetList.Add(tank);
    }

    private void Tank_Dead(Tank tank)
    {
        _animator.SetBool("IsShot", false);
        
        targetList.Remove(tank);

        if (targetList.Count == 0)
        {
            StopCurrentCoroutine();
        }
        
        if (targetList.Count > 0)
        {
            StopCurrentCoroutine();
        }
    }

    private void StopCurrentCoroutine()
    {
        if (_fire != null)
        {
            StopCoroutine(_fire);
            _fire = null;
        }
    }
    
    public IEnumerator Fire(DamageableObject tank)
    {
        var firingDelay = new WaitForSeconds(_firingDelay);

        for (int i = 0; i < _numberShellsPerTank; i++)
        {
            Arrow createdArrow = Instantiate(_arrowPrefab, _arrowSpawnPoint.position, Quaternion.identity, transform);
            
            createdArrow.SetTarget(tank, isTankDead =>
            {
                if (isTankDead)
                {
                    StopCurrentCoroutine();
                }
            });

            yield return firingDelay;
        }
    }
}