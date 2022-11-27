using System.Collections;
using UnityEngine;

public class SpawnTank : MonoBehaviour
{
    [SerializeField] 
    private Tank _tankPrefab = null;

    [SerializeField]
    private int _spawmCount = 0;

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
            var spawnPosition = GetRandomPoint();
            
            Tank createTank = Instantiate(_tankPrefab, spawnPosition, Quaternion.identity, transform);
            createTank.SetTargetPosition(_weapon.transform);

            yield return waiter;
        }
    }

    private Vector3 GetRandomPoint()
    {
        float randomAngleNewDeg = Random.Range(0, 360) * Mathf.Deg2Rad;
        
        var X = Mathf.Cos(randomAngleNewDeg);
        var Z = Mathf.Sin(randomAngleNewDeg);

        var spawnDirection = new Vector3(X, 0, Z);

        return _weapon.transform.position + spawnDirection * (_weapon.GetRadius() * 2);
    }

    private Vector3[] PointsTanksOnCircle()
    {
        float radius = _weapon.GetRadius();
        float ringLength = 2 * 3.14f * radius;
        float angle = 360 * Mathf.Deg2Rad;
        int numberTanksOnCircle = Mathf.RoundToInt(ringLength / _spawmCount);
        
        Vector3 point = _weapon.transform.position; 
        Vector3 originPoint = new Vector3(0, 0, 0);
        Vector3[] pointsArray = new Vector3[_spawmCount];
        
        for (int i = 0; i < pointsArray.Length; i++)
        {
            int randomAngle = Random.Range(0, 360);
            float z = originPoint.x + Mathf.Cos(randomAngle / numberTanksOnCircle) * radius;
            float x = originPoint.z + Mathf.Sin(randomAngle / numberTanksOnCircle) * radius;
            point.x = x;
            point.z = z;
            
            pointsArray[i] = new Vector3(point.x, 0, point.z);
        }

        return pointsArray;
    }
}
