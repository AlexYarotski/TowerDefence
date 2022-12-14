using UnityEngine;

public class SpawnBitcoin : MonoBehaviour
{
    [SerializeField]
    private Bitcoin _btc = null;
    
    [SerializeField] 
    private Weapon _weapon = null;

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
        Bitcoin createBtc = Instantiate(_btc, transform);
        createBtc.transform.position = tank.transform.position;
        createBtc.SetTargetPosition(_weapon.transform);
    }
}
