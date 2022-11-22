using System;
using System.Security.Cryptography;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private int _helth = 0;

    [SerializeField]
    private float _attackRadius = 0;
    
    [SerializeField] 
    private SphereCollider _sphereCollider = null;

    [SerializeField]
    private Arrow _arrowPrefab = null;

    [SerializeField] 
    private Transform _transform = null;

    [SerializeField] 
    private float _shootingSpeed = 0;
    
    [SerializeField] 
    private Tank _tankPrefab = null;

    private void Awake()
    {
        _sphereCollider.radius = _attackRadius;
        _sphereCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Arrow arrow = Instantiate(_arrowPrefab, transform);
    }
}
