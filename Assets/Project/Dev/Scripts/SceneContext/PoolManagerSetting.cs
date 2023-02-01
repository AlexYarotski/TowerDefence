using UnityEngine;

[CreateAssetMenu(fileName = "PoolManagerSetting", menuName = "Settings/PoolManagerSetting", order = 0)]
public class PoolManagerSetting : ScriptableObject
{
    [SerializeField] 
    private PoolConfig[] _poolConfigs = null;

    public PoolConfig[] PoolConfigs => _poolConfigs;
}
