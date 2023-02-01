using Project.Dev.Settings;

public abstract class DamageableObject : PooledBehaviour
{
    private float _health = 0;

    public bool IsDead
    {
        get => _health <= 0;
    }

    private void Awake()
    {
        SceneContext _sceneContext = SceneContext.Singleton;
        DamObjSettings _settings = _sceneContext.GetSettings();
        
        _health = _settings.Health;
    }

    public void GetDamage(float damage)
    {
        _health -= damage;
        
        if (_health <= 0)
        {
            OnDie();
        }
    }

    protected virtual void OnDie()
    {
        gameObject.SetActive(false);
    }
}
