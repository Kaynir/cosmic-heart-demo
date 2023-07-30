using CosmicHeart.Tools.Particles;
using UnityEngine;
using Zenject;

namespace CosmicHeart.Interactions
{
    public class DestructableObject : MonoBehaviour, IDamageable
    {
        [SerializeField] private ParticleSystem deathParticlePrefab = null;

        [Inject] private HealthSystem healthSystem;
        [Inject] private ParticleFactory particleFactory;

        private void OnEnable()
        {
            healthSystem.ValueDepleted += OnHealthDepleted;
        }

        private void OnDisable()
        {
            healthSystem.ValueDepleted -= OnHealthDepleted;
        }

        public void TakeDamage(int amount)
        {
            healthSystem.UpdateValue(-amount);
        }

        private void OnHealthDepleted()
        {
            ParticleSystem deathParticle = particleFactory.Create(deathParticlePrefab);
            deathParticle.transform.position = transform.position;
            deathParticle.transform.localScale = transform.localScale;
            Destroy(gameObject);
        }
    }
}