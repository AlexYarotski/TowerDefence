using System;
using System.Collections;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField]
    private int _helth = 0;

    [SerializeField]
    private float _speed = 0;

    [SerializeField]
    private Tower _towerPrefab = null;

    [SerializeField]
    private int _recharge = 0;
    
    [SerializeField]
    private BoxCollider _boxCollider = null;

    private Renderer _renderer = null;
    
    private void Awake()
    {
        _boxCollider.isTrigger = false;
        _renderer = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        float step = Time.deltaTime * _speed;
        transform.position = Vector3.MoveTowards(transform.position, 
            _towerPrefab.transform.position + new Vector3(0.4f, 1.6f), step);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_boxCollider == collision.collider)
        {
            Destroy(this);
        }
    }
}