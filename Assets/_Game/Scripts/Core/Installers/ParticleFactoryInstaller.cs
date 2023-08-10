using CosmicHeart.Tools.Particles;
using Zenject;

namespace CosmicHeart.Core.Installers
{
    public class ParticleFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ParticleFactory>()
                     .FromNew()
                     .AsSingle()
                     .NonLazy();
        }
    }
}