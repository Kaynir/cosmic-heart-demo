using UnityEngine;
using Zenject;

namespace CosmicHeart.Obstacles
{
    public class ObstacleFactoryInstaller : MonoInstaller
    {
        [SerializeField] private Obstacle prefab = null;

        public override void InstallBindings()
        {
            Container.BindFactory<Obstacle, Obstacle.Factory>()
                     .FromSubContainerResolve()
                     .ByNewContextPrefab(prefab)
                     .UnderTransform(transform)
                     .AsSingle();
        }
    }
}