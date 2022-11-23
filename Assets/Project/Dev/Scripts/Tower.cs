using UnityEngine;

public class Tower : MonoBehaviour
{
    private float _helth = 10;

    public bool HealthLevel(float damage)
    {
        _helth -= damage;

        return LifeCheck();
    }

    private bool LifeCheck()
    {
        if (_helth == 0 || _helth < 0)
        {
            return false;
        }

        return true;
    }
}
