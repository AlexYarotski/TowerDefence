using UnityEngine;

public class PooledBehaviour : MonoBehaviour
{
    public bool IsFree
    {
        get => !gameObject.activeSelf;
    }

    public void Free()
    {
        gameObject.SetActive(false);    
    }

    public virtual void SpawnedFromPool()
    {
        
    }
}
