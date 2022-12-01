using UnityEngine;

public class SpawnPointTank : MonoBehaviour
{
    [SerializeField]
    private Camera _camera = null;

    [SerializeField]
    private Tank _tank = null;
    
    [SerializeField] 
    private Weapon _weapon = null;

    private void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 startPosition = hitInfo.point;
                Tank createTank = Instantiate(_tank, startPosition, Quaternion.identity,
                    transform);
                createTank.SetTargetPosition(_weapon.transform); 
            }
        }
    }
}