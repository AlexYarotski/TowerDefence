using UnityEngine;

namespace Project.Dev.Scripts
{
    public class Fire : MonoBehaviour
    {
        [SerializeField]
        private DamageableObject _target = null;

        [SerializeField]
        private Weapon _weapon = null;
        
        [SerializeField]
        private int _numberShellsPerTank = 0;
        
        private void OnEnable()
        {
            Weapon.ShotTank += Shot_Tank;
        }

        private void OnDisable()
        {
            Weapon.ShotTank -= Shot_Tank;
        }
        
        private void Shot_Tank(DamageableObject target)
        {
            _target = target;
        }

        public void EventFire()
        {
            _weapon.Fire(_target);
        }
    }
}