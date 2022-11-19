using UnityEngine;

internal abstract class Ammunition : MonoBehaviour
{
    public float Speed
    {
        get;
        private set;
    }

    public float Damage
    {
        get;
        private set;
    }

    public Ammunition(float speed, float damage)
    {
        Speed = speed;
        Damage = damage;
    }
}
