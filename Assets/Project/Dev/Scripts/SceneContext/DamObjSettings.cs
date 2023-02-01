using UnityEngine;

namespace Project.Dev.Settings
{
    [CreateAssetMenu(fileName = "DamObjSettings", menuName = "Settings/DamObjSettings", order = 0)]
    public class DamObjSettings : ScriptableObject
    {
        [SerializeField]
        private float _health = 0;

        [SerializeField] 
        private float _damage = 0;

        [SerializeField]
        private float _speed = 0;

        [SerializeField]
        private Animator _animator = null;
        
        public float Health => _health;
        public float Damage => _damage;
        public float Speed => _speed; 
        public Animator Animator => _animator;
    }
}