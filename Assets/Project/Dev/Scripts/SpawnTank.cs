using System.Collections;
using UnityEngine;

public class SpawnTanks : MonoBehaviour, ISpawnPrefab
{
    [SerializeField] 
    private Tank _tankPrefab = null;

    [SerializeField]
    private int _quantityTanks = 0;

    [SerializeField]
    private float _tankSpawnDelay = 0;

    [SerializeField]
    private Transform _StartSpawn = null;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        for (int i = 0; i < _quantityTanks; i++)
        {
            Tank createdTank = Instantiate(_tankPrefab, transform);
            createdTank.transform.position = new Vector3(-5, -3, 1);
            yield return new WaitForSeconds(_tankSpawnDelay);
        }
    }
}
