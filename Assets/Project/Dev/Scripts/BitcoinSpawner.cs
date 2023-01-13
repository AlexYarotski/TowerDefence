using System.Collections;
using Project.Dev.Scripts;
using UnityEngine;

public class BitcoinSpawner : MonoBehaviour
{
    [SerializeField]
    private Bitcoin _btc = null;
    
    [SerializeField] 
    private Tower _tower = null;
    
    [SerializeField] 
    private ParticleSystem _onSpawmCoinsParticlePrefab = null;
    
    [SerializeField] 
    private float _spawnCoinsDelay = 0;
    
    private ParticleSystem _onSpawnCoins = null;

    private void Start()
    {
        _onSpawnCoins = Instantiate(_onSpawmCoinsParticlePrefab, transform);
    }

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
        
        _onSpawnCoins.transform.position = tank.transform.position;
        _onSpawnCoins.Play();

        yield return spawnDelay;
        
        Bitcoin createBtc = Instantiate(_btc, transform);
        createBtc.transform.position = tank.transform.position;
        createBtc.SetTargetPosition(_tower.transform);
    }
}
