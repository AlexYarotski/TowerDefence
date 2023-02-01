using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private readonly Dictionary<PooledType, List<PooledBehaviour>> PooledDictionary = new Dictionary<PooledType, List<PooledBehaviour>>();

    private PoolConfig[] _poolConfigs = null;
    
    private void Awake()
    {
        var settings = SceneContext.Inctance.PoolManagerSetting;

        _poolConfigs = settings.PoolConfigs;
        
        PreparePoolDictionary();
    }

    public T GetObject<T>(PooledType pooledType, Vector3 position) where T : PooledBehaviour
    {
        if (!PooledDictionary.TryGetValue(pooledType, out List<PooledBehaviour> poolBehaviour))
        {
            Debug.LogError("There is no such type!");
            
            return null;
        }
        
        var freePoolObj = TryGetPooledBeh(poolBehaviour);

        if (freePoolObj == null)
        {
            freePoolObj = AddItemToPoolDictionary(poolBehaviour, pooledType);
        }

        freePoolObj.transform.position = position;
        freePoolObj.gameObject.SetActive(true);

        return (T)freePoolObj;
    }

    private PooledBehaviour TryGetPooledBeh(List<PooledBehaviour> poolBehaviour)
    {
        var freePoolObj = poolBehaviour.FirstOrDefault(pb => pb.IsFree);

        if (freePoolObj == null)
        {
            return null;
        }
        
        return freePoolObj;
    }
    
    private PooledBehaviour AddItemToPoolDictionary(List<PooledBehaviour> poolBehaviour, PooledType pooledType)
    {
        var typePoolConfig = _poolConfigs.FirstOrDefault(pt => pt.PooledType == pooledType);

        if (typePoolConfig == default)
        {
            Debug.LogError("There is no such config!");

            return null;
        }
        
        var createObject = Instantiate(typePoolConfig.PooledPrefab, transform);
        poolBehaviour.Add(createObject);
        
        return createObject;
    }

    private void PreparePoolDictionary()
    {
        for (int i = 0; i < _poolConfigs.Length; i++)
        {
            var poolConfig = _poolConfigs[i];
            
            PooledDictionary.Add(poolConfig.PooledType,CreatePoolObjects(poolConfig));
        }
    }

    private List<PooledBehaviour> CreatePoolObjects(PoolConfig poolConfig)
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