using Project.Dev.Settings;
using UnityEngine;

public class SceneContext : MonoBehaviour
{
    [SerializeField]
    private DamObjSettings _damObjSettings = null;
    
    public static SceneContext Singleton
    {
        get;
        private set;
    }

    private void Awake()
    {
        Singleton = this;
    }

    public DamObjSettings GetSettings()
    {
        return _damObjSettings;
    }
}


