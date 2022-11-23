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
            int randomNumberAxis = Random.Range(-9, 9);
            Tank createdTank = Instantiate(_tankPrefab, transform);

            if (randomNumberAxis % 2 == 0)
            {
                createdTank.transform.position = new Vector3(randomNumberAxis, 1, -9);
            }

            else
            {
                createdTank.transform.position = new Vector3(9, 1, randomNumberAxis);
            }
            
            yield return waiter;
        }
    }
}
