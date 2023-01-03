using System;
using UnityEngine;

namespace Project.Dev.Scripts
{
    public class Fire : MonoBehaviour
    {
        [SerializeField] 
        private Weapon _weapon = null;

        [SerializeField]
        private DamageableObject _target = null;

        public void EventFire()
        {
            _weapon.Fire(_target);
        }
    }
}