using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private readonly Dictionary<PooledType, List<PooledBehaviour>> PooledDictionary= new Dictionary<PooledType, List<PooledBehaviour>>();

    [SerializeField] 
    private PoolConfig[] _poolConfig = null;
    
    private void Awake()
    {
        ReplenishmentPoolDictionary();
    }

    public T GetObject<T>(PooledType pooledType, Vector3 position) where T : PooledBehaviour
    {
        List<PooledBehaviour> poolBehaviour = PooledDictionary[pooledType];

        var freePoolObj = poolBehaviour.FirstOrDefault(pb => pb.IsFree);

        if (freePoolObj == null)
        {
            AddItemToPoolDictionary(poolBehaviour);
        }
        
        freePoolObj.transform.position = position;
        freePoolObj.gameObject.SetActive(true);

        return (T)freePoolObj;
    }

    private void AddItemToPoolDictionary(List<PooledBehaviour> poolBehaviour)
    {
        
    }
    
    private void ReplenishmentPoolDictionary()
    {
        for (int i = 0; i < _poolConfig.Length; i++)
        {
            var poolConfig = _poolConfig[i];
            
            PooledDictionary.Add(poolConfig.PooledType,CreaturePoolObject(poolConfig));
        }
    }

    private List<PooledBehaviour> CreaturePoolObject(PoolConfig poolConfig)
    {
        var poolList = new List<PooledBehaviour>(poolConfig.Count);

        for (int i = 0; i < poolConfig.Count; i++)
        {
            var poolObject = Instantiate(poolConfig.PooledPrefab, transform);
            poolObject.Free();

            poolList.Add(poolObject);
        }

        return poolList;
    }
}
