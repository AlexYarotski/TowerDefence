using System.Collections;
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

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        
        _sphereCollider.radius = _attackRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Tank tank))
        {
            StartCoroutine(Fire(tank));
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

    public float GetRadius()
    {
        return _attackRadius;
    }
}