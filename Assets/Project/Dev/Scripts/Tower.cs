using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private BoxCollider _collider = null;
    
    [SerializeField]
    private float _healtha = 10;

    private void Awake()
    {
        _collider.isTrigger = false;
        this.gameObject.SetActive(true);
    }

    public bool HealthLevel(float damage)
    {
        _healtha -= damage;

        return _healtha == 0 || _healtha < 0;
    }
}
