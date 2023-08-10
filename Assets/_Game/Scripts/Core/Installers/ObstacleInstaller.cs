using CosmicHeart.Interactions;
using CosmicHeart.Obstacles;
using UnityEngine;
using Zenject;

namespace CosmicHeart.Core.Installers
{
    public class ObstacleInstaller : MonoInstaller
    {
        [SerializeField] private ObstacleConfig config = null;
        [SerializeField] private Obstacle obstacle = null;

        public override void InstallBindings()
        {
            var settings = config.GetSettings();
            var healthSystem = new HealthSystem(settings.health);
            var transform = obstacle.transform;

            obstacle.Body.mass = settings.mass;
            
            transform.rotation = settings.rotation;
            transform.localScale = settings.localScale;

            Container.Bind<HealthSystem>()
                     .FromInstance(healthSystem)
                     .AsSingle();
        }
    }
}