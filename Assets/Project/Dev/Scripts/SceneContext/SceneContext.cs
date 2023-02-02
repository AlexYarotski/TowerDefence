using System;
using Project.Dev.Settings;
using UnityEngine;

public class SceneContext : MonoBehaviour
{
    [field: SerializeField]
    public TankSettings TankSettings
    {
        get;
        private set;
    }

    [field: SerializeField]
    public BitcoinSettings BitcoinSettings
    {
        get;
        private set;
    }

    [field: SerializeField]
    public TowerSettings TowerSettings
    {
        get;
        private set;
    }

    [field: SerializeField]
    public ArrowSettings ArrowSettings
    {
        get;
        private set;
    }
    
    [field: SerializeField]
    public WeaponSettings WeaponSettings
    {
        get;
        private set;
    }

    [field: SerializeField]
    public PoolManagerSetting PoolManagerSetting
    {
        get;
        private set;
    }
    
    public static SceneContext Inctance
    {
        get; 
        private set;
    }

    private void Awake()
    {
        if (Inctance == null)
        {
            Inctance = this;
        }
        else if(Inctance == this)
        {
            Destroy(gameObject);
        }
    }

}


