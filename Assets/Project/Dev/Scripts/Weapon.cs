using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Arrow _arrowPrefab = null;

    [SerializeField]
    private float _attackRadius = 0;

    [SerializeField] 
    private float _firingDelay = 0;

    [SerializeField] 
    private int _numberShellsPerTank = 0;

    [SerializeField]
    private Transform _arrowSpawnPoint = null;

    private SphereCollider _sphereCollider = null;
    private List<Tank> tankDead = new List<Tank>();
    private Coroutine _fire = null;

    public float GetRadius()
    {
        return _attackRadius;
    }
    
    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        
        _sphereCollider.radius = _attackRadius;
    }
    
    private void OnEnable()
    {
        Tank.Dead += Tank_Dead;
    }

    private void OnDisable()
    {
        Tank.Dead -= Tank_Dead;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Tank tank))
        {
            tankDead.Add(tank);
            
            if (_fire == null || tankDead.Count == 1)
            {
                _fire = StartCoroutine(Fire(tank));
            }
        }
    }

    private void Tank_Dead(Tank tank)
    {
        tankDead.Remove(tank);

        if (tankDead.Count > 0)
        {
            int minTankDistance = SearchNearestTankIndex();

            StopCurrentCoroutine();

            _fire = StartCoroutine(Fire(tankDead[minTankDistance]));
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

    private int SearchNearestTankIndex()
    {
        int minTankDistance = 0;
        float distanceFirstTank = (tankDead[0].transform.position - transform.position).sqrMagnitude;
        
        if (tankDead.Count == 1)
        {
            return minTankDistance;
        }

        for (int i = 1; i < tankDead.Count; i++)
        {
            float distanceNextTank = (tankDead[i].transform.position - transform.position).sqrMagnitude;

            if (distanceFirstTank > distanceNextTank);
            {
                distanceFirstTank = distanceNextTank;
                minTankDistance = i;
            }
        }
        
        return minTankDistance; 
    }

    private IEnumerator Fire(Tank tank)
    {
        var firingDelay = new WaitForSeconds(_firingDelay);
            
        for (int i = 0; i < _numberShellsPerTank; i++)
        { 
            if (!tank.IsDead)
            {
                Arrow createdArrow = Instantiate(_arrowPrefab, _arrowSpawnPoint.position, Quaternion.identity, transform);
                createdArrow.SetTarget(tank);

                yield return firingDelay;
            }
            
            break;
        }
    }
}