using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnTank : MonoBehaviour
{
    [SerializeField] 
    private Tank _tankPrefab = null;

    [SerializeField]
    private int _spawmCount = 0;

    [SerializeField]
    private float _spawnDelay = 0;

    [SerializeField]
    private Transform _startSpawn = null;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waiter = new WaitForSeconds(_spawnDelay);

        for (int i = 0; i < _spawmCount; i++)
        {
            int randomX = Random.Range(-5, 4);
            int randomZ = Random.Range(-4, 4);
            
            Tank createdTank = Instantiate(_tankPrefab, transform);
            createdTank.transform.position = new Vector3(randomX, 0.5f, randomZ);
           
            yield return waiter;
        }
    }
}
