using UnityEngine;

namespace Project.Dev.Scripts
{
    public class ParticleManager : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _onDieTankParticlePrefab = null;

        private ParticleSystem _onDieTank = null;

        private void Start()
        {
            _onDieTank = Instantiate(_onDieTankParticlePrefab, transform);
        }

        private void OnEnable()
        {
            Tank.Dead += Tank_Dead;
        }

        private void OnDisable()
        {
            Tank.Dead += Tank_Dead;
        }

        private void Tank_Dead(Tank obj)
        {
            _onDieTank.transform.position = obj.transform.position;
            _onDieTank.Play();
        }
    }
}