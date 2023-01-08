using System;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    public static event Action<DamageableObject> ShotTank = delegate {  };
    
    [SerializeField] 
    private Weapon _weapon = null;

    [SerializeField] 
    private Animator _animator = null;

    private List<DamageableObject> targetList = new List<DamageableObject>();
    
    public void Shot()
    {
        if (CanShot())
        {
            var searchNearestTank = SearchNearestTank();
            
            ShotTank(searchNearestTank);

            _animator.SetBool("IsShot", true);
            
            targetList.Remove(searchNearestTank);
        }
    }
    
    private void Start()
    {
        targetList = _weapon.GetTarget();
    }
    
    private DamageableObject SearchNearestTank()
    {
        int minTankDistanceIndex = 0;
        float minDistanceTank = (targetList[0].transform.position - transform.position).sqrMagnitude;

        if (targetList.Count == 1)
        {
            return targetList[0];
        }

        for (int i = 1; i < targetList.Count; i++)
        {
            float distanceTank = (targetList[i].transform.position - transform.position).sqrMagnitude;

            if (minDistanceTank > distanceTank);
            {
                minDistanceTank = distanceTank;
                minTankDistanceIndex = i;
            }
        }
        
        return targetList[minTankDistanceIndex]; 
    }

    private bool CanShot()
    {
        if (targetList.Count != 0)
        {
            var distation = (transform.position + new Vector3 (10, 0, 10)).sqrMagnitude;
            var targetPosition = (SearchNearestTank().transform.position).sqrMagnitude;

            if (targetPosition <= distation)
            {
                return true;
            }
        }

        return false;
    }
}
