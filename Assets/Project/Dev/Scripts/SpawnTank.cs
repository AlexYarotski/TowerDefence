using System.Collections;
using UnityEngine;

public class SpawnTank : MonoBehaviour
{
    [SerializeField] 
    private Tank _tankPrefab = null;

    [SerializeField]
    private float _spawnDelay = 0;
    
    [SerializeField] 
    private Weapon _weapon = null;
    
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waiter = new WaitForSeconds(_spawnDelay);

        while (true)
        {
            Vector3 spawnPosition = GetRandomPoint();
            
            Tank createTank = Instantiate(_tankPrefab, spawnPosition, Quaternion.identity, transform);
            //createTank.SetTargetPosition(_weapon.transform);
            
            yield return waiter;
        }
    }

    private Vector3 GetRandomPoint()
    {
        float randomAngleNewDeg = Random.Range(0, 360) * Mathf.Deg2Rad;
        float x = Mathf.Cos(randomAngleNewDeg);
        float z = Mathf.Sin(randomAngleNewDeg);

        Vector3 spawnDirection = new Vector3(x, 0, z);

        return _weapon.transform.position + spawnDirection * (_weapon.GetRadius() * 2);
    }
}
