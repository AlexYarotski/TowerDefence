using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private Camera _camera = null;

    [SerializeField]
    private Tank _tank = null;

    private void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 startPosition = (hitInfo.point - transform.position).normalized;
                Tank createTank = Instantiate(_tank, transform);
                createTank.transform.position = startPosition;
            }
        }
    }
}
