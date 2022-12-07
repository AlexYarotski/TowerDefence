using System.Collections;
using UnityEngine;

public class Bitcoin : MonoBehaviour
{
    [SerializeField] 
    private float _rotation = 0;

    [SerializeField] 
    private float _flightDelay = 0;

    [SerializeField] 
    private float _flightSpeed = 0;
    
    [SerializeField] 
    private Tower _tower = null;

    private void OnEnable()
    {
        Tank.Dead += Tank_Dead;
    }

    private void Tank_Dead(Tank tank)
    {
        transform.position = tank.transform.position ;
        StartCoroutine(FlightDelay());
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, _rotation, 0);
        
        var finalPos = new Vector3(_tower.transform.position.x, 1, _tower.transform.position.z);
        float step = Time.deltaTime * _flightSpeed;
        
        var moveDirection = (finalPos - transform.position).normalized * step;
        transform.position += moveDirection;
    }

    private IEnumerator FlightDelay()
    {
        var waiter = new WaitForSeconds(_flightDelay);

        for (int i = 0; i < 2; i++)
        {
            

            yield return waiter;
        }
    }
}
