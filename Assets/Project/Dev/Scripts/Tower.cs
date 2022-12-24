using System;

public class Tower : DamageableObject
{
    public static event Action<Tower> Dead = delegate { };
    
    protected override void OnDie()
    {
        base.OnDie();
        
        Dead(this);
    }
}
