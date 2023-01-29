using System.Collections.Generic;
using Project.Dev.Scripts;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    private readonly List<DamageableObject> TargetList = new List<DamageableObject>();

    [SerializeField]
    private Weapon _weapon = null;

    private DamageableObject _target = null;
    private void OnEnable()
    {
        TankPointSpawner.Spawned += TatnkPoinSpawner_Spawned;
        Weapon.ShotTank += Weapon_ShotTank;
    }
    
    private void OnDisable()
    {
        TankPointSpawner.Spawned -= TatnkPoinSpawner_Spawned;
        Weapon.ShotTank -= Weapon_ShotTank;
    }

    public bool CanShot()
    {
        if (HasTank())
        {
            _target = SearchNearestTank();
            var distanceToTower = (SearchNearestTank().transform.position - transform.position).sqrMagnitude;
            
            if (distanceToTower <= _weapon.GetRadius())
            {
                return true;
            }
        }
        
        return false;
    }
    
    public DamageableObject SearchNearestTank()
    {
        var minTankDistanceIndex = 0;
        var minDistanceTank = (TargetList[0].transform.position - transform.position).sqrMagnitude;

        if (TargetList.Count == 1)
        {
            return TargetList[0];
        }

        for (int i = 1; i < TargetList.Count; i++)
        {
            float distanceTank = (TargetList[i].transform.position - transform.position).sqrMagnitude;

            if (minDistanceTank > distanceTank)
            {
                minDistanceTank = distanceTank;
                minTankDistanceIndex = i;
            }
        }
        
        return TargetList[minTankDistanceIndex]; 
    }

    private bool HasTank()
    {
        return TargetList.Count != 0;
    }
    
    private void TatnkPoinSpawner_Spawned(DamageableObject target)
    {
        TargetList.Add(target);
    }

    private void Weapon_ShotTank(DamageableObject target)
    {
        TargetList.Remove(target);
    }
}