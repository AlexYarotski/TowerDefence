using UnityEngine;

public class PooledBehaviour : MonoBehaviour
{
    public bool IsFree
    {
        get => !gameObject.activeSelf;
    }
}
