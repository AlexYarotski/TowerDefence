using UnityEngine;

namespace Project.Dev.Settings
{
    [CreateAssetMenu(fileName = "TowerSettings", menuName = "Settings/TowerSettings", order = 0)]
    public class TowerSettings : ScriptableObject
    {
        [SerializeField] 
        private float _health = 0;
        
        public float Health => _health;
    }
}