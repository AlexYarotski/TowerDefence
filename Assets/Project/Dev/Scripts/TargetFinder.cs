using System.Collections.Generic;
using Project.Dev.Scripts;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    [SerializeField]
    private Weapon _weapon = null;
    
    private readonly List<DamageableObject> _targetList = new List<DamageableObject>();

    private void OnEnable()
    {
        TatnkPoinSpawner.Spawn += Spawn_Tank;
        Weapon.ShotTank += Shot_Tank;
        Tank.Dead += Tank_Dead;
    }
    
    private void OnDisable()
    {
        TatnkPoinSpawner.Spawn -= Spawn_Tank;
        Weapon.ShotTank -= Shot_Tank;
        Tank.Dead -= Tank_Dead;
    }

    public bool CanShot()
    {
        if (HasTank())
        {
            var distationToTower = (SearchNearestTank().transform.position - transform.position).sqrMagnitude;
            
            if (distationToTower <= _weapon.GetRadius())
            {
                return true;
            }
        }
        
        return false;
    }
    
    public DamageableObject SearchNearestTank()
    {
        int minTankDistanceIndex = 0;
        float minDistanceTank = (_targetList[0].transform.position - transform.position).sqrMagnitude;

        if (_targetList.Count == 1)
        {
            return _targetList[0];
        }

        for (int i = 1; i < _targetList.Count; i++)
        {
            float distanceTank = (_targetList[i].transform.position - transform.position).sqrMagnitude;

            if (minDistanceTank > distanceTank);
            {
                minDistanceTank = distanceTank;
                minTankDistanceIndex = i;
            }
        }
        
        return _targetList[minTankDistanceIndex]; 
    }

    private bool HasTank()
    {
        return _targetList.Count != 0;
    }
    
    private void Spawn_Tank(DamageableObject target)
    {
        _targetList.Add(target);
    }

    private void Shot_Tank(DamageableObject target)
    {
        _targetList.Remove(target);
    }
    
    private void Tank_Dead(DamageableObject target)
    {
        _targetList.Remove(target);
    }
}