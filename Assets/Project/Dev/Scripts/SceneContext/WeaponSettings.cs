using UnityEngine;

namespace Project.Dev.Settings
{
    [CreateAssetMenu(fileName = "WeaponSettings", menuName = "Settings/WeaponSettings", order = 0)]
    public class WeaponSettings : ScriptableObject
    {
        [SerializeField] 
        private float _attackRadius = 0;

        [SerializeField] 
        private float speedAttack = 0;

        public float AttackRadius => _attackRadius;
        public float SpeedAttack => speedAttack;
    }
}