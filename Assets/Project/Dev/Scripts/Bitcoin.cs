using UnityEngine;

public class Bitcoin : MonoBehaviour
{
    [SerializeField] 
    private float _angle = 0;
    
    [SerializeField] 
    private float _flightSpeed = 0;

    private Transform _target = null;
    
    void FixedUpdate()
    {
        Rotation();
        
        var finalPos = new Vector3(_target.transform.position.x, 1, _target.transform.position.z);
        float step = Time.deltaTime * _flightSpeed;

        var moveDirection = (finalPos - transform.position).normalized * step;
        transform.position += moveDirection;
    }

    private void Rotation()
    {
        Quaternion rotationZ = Quaternion.AngleAxis(_angle, new Vector3(0, 0, 1));
        transform.rotation *= rotationZ;
    }
    
    public void SetTargetPosition(Transform targetTransform)
    {
        _target = targetTransform;
    } 
}
