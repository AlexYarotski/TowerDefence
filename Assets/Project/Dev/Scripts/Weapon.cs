using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Arrow _arrowPrefab = null;

    [SerializeField]
    private float _attackRadius = 0;

    [SerializeField] 
    private float _rateFire = 0;

    private SphereCollider _sphereCollider = null;
    
    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();

        _sphereCollider.radius = _attackRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Tank tank))
        {
            //StartCoroutine(Fire());
        }
    }
}