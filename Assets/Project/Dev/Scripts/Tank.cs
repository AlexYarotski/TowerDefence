using UnityEngine;
using System;
using System.Collections;

namespace Project.Dev.Scripts
{
    public class Tank : DamageableObject
    {
        private const float TankHeightFromZeroPoint = 1.5f;
        
        public static event Action<Tank> Dead = delegate { };

        private float _speed = 0;
        private float _damage = 0;
        private Tower _target = null;
        private float _startHealth = 0;

        private void Awake()
        {
            var settings = SceneContext.Inctance.TankSettings;
            
            _speed = settings.Speed;
            _damage = settings.Damage;
            _health = settings.Health;
            _startHealth = _health;
        }
        
        public void SetTargetPosition(Tower target)
        {
            _target = target;

            var rotation = Quaternion.LookRotation((_target.transform.position - transform.position).normalized, 
                Vector3.up).normalized;
            transform.rotation = rotation;
            
            StartCoroutine(MovementToTower());
        }

        public override void SpawnedFromPool()
        {
            base.SpawnedFromPool();

            _health = _startHealth;
        }
        
        protected override void OnDie()
        {
            base.OnDie();

            Dead(this);
        }

        private IEnumerator MovementToTower()
        {
            SpawnedFromPool();
            
            var finalPos = new Vector3(_target.transform.position.x, TankHeightFromZeroPoint,
                _target.transform.position.z);
            var position = transform.position;
            
            float currentTime = 0;
            float towerDistance = (finalPos - transform.position).magnitude;
            float towerMoveTime = towerDistance / _speed;

            while (currentTime < towerMoveTime)
            {
                float progress = currentTime / towerMoveTime;

                transform.position = Vector3.Lerp(position, finalPos, progress);

                yield return null;

                currentTime += Time.deltaTime;
            }

            TargetDamage();
        }

        private void TargetDamage()
        {
            _target.GetDamage(_damage);

            OnDie();
        }
    }
}