using UnityEngine;

namespace Project.Dev.Scripts
{
    public class Fire : MonoBehaviour
    {
        [SerializeField]
        private DamageableObject _target = null;

        [SerializeField]
        private Weapon _weapon = null;
        
        private void OnEnable()
        {
            TargetFinder.ShotTank += Shot_Tank;
        }

        private void OnDisable()
        {
            TargetFinder.ShotTank -= Shot_Tank;
        }
        
        private void Shot_Tank(DamageableObject target)
        {
            _target = target;
        }

        public void EventFire()
        {
            StartCoroutine(_weapon.Fire(_target));
        }
    }
}