using System;
using System.Collections;
using Project.Dev.Scripts;
using UnityEngine;

public class BitcoinSpawner : MonoBehaviour
{
    public static event Action<BitcoinSpawner> BitcoinSpawned = delegate { };

    [SerializeField] 
    private Tower _tower = null;

    [SerializeField] 
    private float _spawnCoinsDelay = 0;

    [SerializeField]
    private PoolManager _poolManager = null;
        
    private void OnEnable()
    {
        Tank.Dead += Tank_Dead;
    }

    private void OnDisable()
    {
        Tank.Dead -= Tank_Dead;
    }
    
    private void Tank_Dead(Tank tank)
    {
        StartCoroutine(Spawn(tank));
    }

    private IEnumerator Spawn(Tank tank)
    {
        var spawnDelay = new WaitForSeconds(_spawnCoinsDelay);
        yield return spawnDelay;

        var position = tank.transform.position;
        var createBtc = _poolManager.GetObject<Bitcoin>(PooledType.Bitcoin, position);
        
        BitcoinSpawned(this);
        
        createBtc.SetTargetPosition(_tower.transform);
    }
}
