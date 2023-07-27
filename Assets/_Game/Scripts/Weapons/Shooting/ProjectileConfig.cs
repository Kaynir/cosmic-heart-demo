using CosmicHeart.Tools.Static;
using UnityEngine;

namespace CosmicHeart.Weapons.Shooting
{
    [CreateAssetMenu(menuName = AssetMenuConsts.WEAPON_CONFIG_PATH + "Projectile Config")]
    public class ProjectileConfig : ScriptableObject
    {
        [Header("Launch Settings:")]
        [SerializeField] private float launchForce = 25f;
        [SerializeField] private float lifeTime = 5f;
        
        [Header("Impact Settings:")]
        [SerializeField] private int impactDamage = 10;
        [SerializeField] private ParticleSystem impactParticlePrefab = null;

        public float LaunchForce => launchForce;
        public float LifeTime => lifeTime;

        public int ImpactDamage => impactDamage;
        public ParticleSystem ImpactParticlePrefab => impactParticlePrefab;
    }
}