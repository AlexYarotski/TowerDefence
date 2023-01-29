using UnityEngine;

namespace Project.Dev.Scripts
{
    public class Fire : MonoBehaviour
    {
        [SerializeField]
        private Weapon _weapon = null;

        private DamageableObject _target = null;
        
        private void OnEnable()
        {
            Weapon.ShotTank += Weapon_ShotTank;
        }

        private void OnDisable()
        {
            Weapon.ShotTank -= Weapon_ShotTank;
        }
        
        //NOTE: used as event in "IsShot" animation
        public void EventFire()
        {
            _weapon.Fire(_target);
        }
        
        private void Weapon_ShotTank(DamageableObject target)
        {
            _target = target;
        }
    }
}