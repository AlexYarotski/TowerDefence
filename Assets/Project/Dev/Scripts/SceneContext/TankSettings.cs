using UnityEngine;

namespace Project.Dev.Settings
{
    [CreateAssetMenu(fileName = "TankSettings", menuName = "Settings/TankSettings", order = 0)]
    public class TankSettings : ScriptableObject
    {
        [SerializeField] 
        private float _damage = 0;

        [SerializeField]
        private float _speed = 0;

        [SerializeField] 
        private float _health = 0;
        
        public float Damage => _damage;
        public float Speed => _speed;
        public float Health => _health;
    }
} 