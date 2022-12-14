using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private Tank _target = null;
    private bool _firstDead = true;

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
            
            if (_firstDead)
            {
                StartCoroutine(Fire(tankDead.First()));
                tankDead.Remove(tank);
                _firstDead = false;
            }
        }
    }

    private void Tank_Dead(Tank tank)
    {
        _target = tank;
        
        if(tankDead.Count > 0)
        {
            int minTankDistance = SearchNearestTank();
            
            StartCoroutine(Fire(tankDead[minTankDistance]));
            tankDead.RemoveAt(minTankDistance);
            return;
        }

        _firstDead = true;
    }

    private int SearchNearestTank()
    {
        int minTankDistance = 0;
        
        if (tankDead.Count == 1)
        {
            return minTankDistance;
        }
        
        for (int i = 1; i < tankDead.Count; i++)
        {
            float distanceFirstTank = (tankDead[0].transform.position - transform.position).sqrMagnitude;
            float distanceNextTank = (tankDead[i].transform.position - transform.position).sqrMagnitude;

            if (distanceFirstTank < distanceNextTank);
            {
                minTankDistance = i;
            }
        }
        
        return minTankDistance; 
    }

    private IEnumerator Fire(Tank tank)
    {
        var firingDelay = new WaitForSeconds(_firingDelay);
        float healthTank = tank.health; 
            
        for (int i = 0; i < _numberShellsPerTank; i++)
        { 
            Arrow createdArrow = Instantiate(_arrowPrefab, _arrowSpawnPoint.position, Quaternion.identity, transform);
            createdArrow.SetTarget(tank);
            
            healthTank =- createdArrow.damage;

            if (healthTank <= 0)
            {
                yield return firingDelay;
                
                break;
            }

            yield return firingDelay;
        }
    }
}