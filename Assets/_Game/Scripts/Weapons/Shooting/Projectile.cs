using System;
using CosmicHeart.Interactions;
using CosmicHeart.Movement.Launchables;
using CosmicHeart.Tools.Particles;
using CosmicHeart.Tools.Static;
using UnityEngine;
using Zenject;

namespace CosmicHeart.Weapons.Shooting
{
    public class Projectile : MonoBehaviour, IPoolable<ProjectileConfig, IMemoryPool>, IDisposable
    {
        [Inject] private ParticleFactory particleFactory;

        private ProjectileConfig config;
        private IMemoryPool pool;

        private ILaunchable launchable;

        private void Awake()
        {
            launchable = GetComponent<ILaunchable>();
        }

        public void Launch(Transform firePoint, Transform target)
        {
            launchable.Lauch(new LaunchSettings()
            {
                origin = firePoint,
                target = target,
                force = config.LaunchForce
            });
        }

        public void OnDespawned()
        {
            pool = null;
        }

        public void OnSpawned(ProjectileConfig config, IMemoryPool pool)
        {
            this.config = config;
            this.pool = pool;
            this.WaitForAction(config.LifeTime, Dispose);
        }

        public void Dispose()
        {
            pool.Despawn(this);
        }

        private void OnCollisionEnter(Collision other)
        {
            var target = other.collider.GetComponentInParent<IDamageable>();
            var impactParticle = particleFactory.Create(config.ImpactParticlePrefab);

            target?.TakeDamage(config.ImpactDamage);
            impactParticle.transform.position = other.GetContact(0).point;

            Dispose();
        }

        public class Factory : PlaceholderFactory<ProjectileConfig, Projectile> { }
    }
}