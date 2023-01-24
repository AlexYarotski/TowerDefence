using System;
using UnityEngine;

[Serializable]
public class PoolConfig : PooledBehaviour
{
    [SerializeField]
    private int _count = 0;
    
    [SerializeField]
    private PooledType _pooledType = default;
    
    [SerializeField]
    private PooledBehaviour _pooledPrefab = null;

    public int Count => _count;
    public PooledType PooledType => _pooledType;
    public PooledBehaviour PooledPrefab => _pooledPrefab;
}
