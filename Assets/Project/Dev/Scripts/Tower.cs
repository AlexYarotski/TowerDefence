using UnityEngine;

public class Tower : DamageableObject
{
    [SerializeField]
    private float _health = 0;

    private void Start()
    {
        Health = _health;
    }
}
