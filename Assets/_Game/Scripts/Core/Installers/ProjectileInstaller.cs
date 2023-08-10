using CosmicHeart.Weapons.Shooting;
using UnityEngine;
using Zenject;

namespace CosmicHeart.Core.Installers
{
    public class ProjectileInstaller : MonoInstaller
    {
        private const string PARENT_NAME = "Projectiles";

        [SerializeField] private Projectile prefab = null;
        [SerializeField, Min(0)] private int poolSize = 10;

        public override void InstallBindings()
        {
            BindFactory();
        }

        private void BindFactory()
        {
            Container.BindFactory<ProjectileConfig, Projectile, Projectile.Factory>()
                     .FromMonoPoolableMemoryPool(pool =>
                     {
                        pool.WithInitialSize(poolSize)
                            .ExpandByOneAtATime()
                            .FromComponentInNewPrefab(prefab)
                            .UnderTransformGroup(PARENT_NAME);
                     });
        }
    }
}