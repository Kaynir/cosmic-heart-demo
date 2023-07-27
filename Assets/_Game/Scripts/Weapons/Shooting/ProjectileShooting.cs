using UnityEngine;
using Zenject;

namespace CosmicHeart.Weapons.Shooting
{
    public class ProjectileShooting : ShootingModule
    {
        [SerializeField] private ProjectileConfig config = null;

        [Inject] private Projectile.Factory projectileFactory;

        public override void ExecuteShot(Transform firePoint, Transform target)
        {
            Projectile projectile = projectileFactory.Create(config);
            projectile.transform.position = firePoint.position;
            projectile.Launch(firePoint, target);
        }
    }
}