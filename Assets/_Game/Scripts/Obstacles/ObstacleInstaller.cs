using CosmicHeart.Interactions;
using UnityEngine;
using Zenject;

namespace CosmicHeart.Obstacles
{
    public class ObstacleInstaller : MonoInstaller
    {
        [SerializeField] private ObstacleConfig config = null;
        [SerializeField] private Rigidbody body = null;

        public override void InstallBindings()
        {
            var settings = config.GetSettings();
            var healthSystem = new HealthSystem(settings.health);
            var transform = body.transform;

            body.mass = settings.mass;
            
            transform.rotation = settings.rotation;
            transform.localScale = settings.localScale;

            Container.Bind<HealthSystem>()
                     .FromInstance(healthSystem)
                     .AsSingle();
        }
    }
}