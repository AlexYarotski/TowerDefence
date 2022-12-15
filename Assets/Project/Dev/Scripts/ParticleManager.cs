using System.Collections.Generic;
using UnityEngine;

namespace Project.Dev.Scripts
{
    public class ParticleManager : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _onDieTankParticlePrefab = null;
        
        [SerializeField]
        private ParticleSystem _onDieTowerParticlePrefab = null;
        
        
        private ParticleSystem _onDieTower = null;
        private ParticleSystem _onDieTank = null;
        
        
        private void Start()
        {
            _onDieTank = Instantiate(_onDieTankParticlePrefab, transform);
            _onDieTower = Instantiate(_onDieTowerParticlePrefab, transform);
        }

        private void OnEnable()
        {
            Tank.Dead += Tank_Dead;
            Tower.Dead += Tower_Dead;
        }

        private void OnDisable()
        {
            Tank.Dead -= Tank_Dead;
            Tower.Dead -= Tower_Dead;
        }

        private void Tank_Dead(Tank tank)
        {
            _onDieTank.transform.position = tank.transform.position;
            _onDieTank.Play();
        }
        
        private void Tower_Dead(Tower tower)
        {
            _onDieTower.transform.position = tower.transform.position;
            _onDieTower.Play();
        }
    }
}