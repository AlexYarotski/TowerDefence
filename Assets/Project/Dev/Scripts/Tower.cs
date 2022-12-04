using System;

public class Tower : DamageableObject
{
    public static event Action<Tower> Dead = delegate { };
    
    public override void OnDie()
    {
        base.OnDie();
        Dead(this);
    }
}
