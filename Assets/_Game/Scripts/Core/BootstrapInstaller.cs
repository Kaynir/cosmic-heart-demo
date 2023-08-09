using Kaynir.SceneExtension;
using Zenject;

namespace CosmicHeart.Core
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>()
                     .ToSelf()
                     .FromComponentInHierarchy()
                     .AsSingle();
        }
    }
}