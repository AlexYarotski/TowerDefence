﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Weapon : MonoBehaviour
{
    public static event Action<Tank> ShotTank = delegate {  };
    
    [SerializeField]
    private float _attackRadius = 0;

    [SerializeField] 
    private float _firingDelay = 0;

    [SerializeField] 
    private int _numberShellsPerTank = 0;
    
    [SerializeField]
    private Arrow _arrowPrefab = null;

    [SerializeField]
    private Transform _arrowSpawnPoint = null;

    [SerializeField]
    private Animator _animator = null;
    
    private SphereCollider _sphereCollider = null;
    private List<Tank> targetList = new List<Tank>();
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
            ShotTank(tank);
            
            targetList.Add(tank);

            if (_fire == null)
            {
                _fire = StartCoroutine(Fire(tank));
            }
        }
    }

    private void Tank_Dead(Tank tank)
    {
        targetList.Remove(tank);

        if (targetList.Count == 0)
        {
            StopCurrentCoroutine();
        }
        
        if (targetList.Count > 0)
        {
            var minTankDistance = SearchNearestTank();

            StopCurrentCoroutine();

            _fire = StartCoroutine(Fire(minTankDistance));
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

    private Tank SearchNearestTank()
    {
        int minTankDistanceIndex = 0;
        float minDistanceTank = (targetList[0].transform.position - transform.position).sqrMagnitude;

        if (targetList.Count == 1)
        {
            return targetList.First();
        }

        for (int i = 1; i < targetList.Count; i++)
        {
            float distanceTank = (targetList[i].transform.position - transform.position).sqrMagnitude;

            if (minDistanceTank > distanceTank);
            {
                minDistanceTank = distanceTank;
                minTankDistanceIndex = i;
            }
        }
        
        return targetList[minTankDistanceIndex]; 
    }

    private IEnumerator Fire(Tank tank)
    {
        var firingDelay = new WaitForSeconds(_firingDelay);

        for (int i = 0; i < _numberShellsPerTank; i++)
        {
            _animator.SetBool("IsShot", true);
            Arrow createdArrow = Instantiate(_arrowPrefab, _arrowSpawnPoint.position, Quaternion.identity, transform);
            
            createdArrow.SetTarget(tank, isTankDead =>
            {
                if (isTankDead)
                {
                    StopCurrentCoroutine();
                }
            });

            _animator.SetBool("IsShot", false);
            yield return firingDelay;
            
        }
    }
}