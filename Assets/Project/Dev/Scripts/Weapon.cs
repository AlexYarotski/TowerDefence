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
    private bool _firsDead = true;

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
            
            if (_firsDead)
            {
                StartCoroutine(Fire(tankDead.First()));
                tankDead.Remove(tank);
                _firsDead = false;
            }
        }
    }

    private void Tank_Dead(Tank tank)
    {
        _target = tank;
        
        SearchNearestTank();
        
        if (tankDead.Count >= 1)
        {
            StartCoroutine(Fire(tankDead.First()));
            tankDead.RemoveAt(0);
            return;
        }

        _firsDead = true;
    }

    private void SearchNearestTank()
    {
        for (int i = 0; i < tankDead.Count - 1; i++)
        {
            for (int j = 0; j < tankDead.Count - 1 -i; j++)
            {
                float distanceFirstTank = (tankDead[j].transform.position - transform.position).sqrMagnitude;
                float distanceNextTank = (tankDead[j + 1].transform.position - transform.position).sqrMagnitude;
                
                if (distanceFirstTank > distanceNextTank)
                {
                    Tank sort = tankDead[i + 1];
                    tankDead[j + 1] = tankDead[j];
                    tankDead[j] = sort;
                }
                
            }
        }
    }

    private IEnumerator Fire(Tank tank)
    {
        var firingDelay = new WaitForSeconds(_firingDelay);
        
        for (int i = 0; i < _numberShellsPerTank; i++)
        {
            Arrow createdArrow = Instantiate(_arrowPrefab, _arrowSpawnPoint.position, Quaternion.identity, transform);
            
            createdArrow.SetTarget(tank);
            
            yield return firingDelay;
        }
    }
}