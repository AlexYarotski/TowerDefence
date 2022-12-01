using UnityEngine;

public class Tower : Life
{
    [SerializeField]
    private float _health = 0;

    private void Start()
    {
        Health = _health;
    }
}
