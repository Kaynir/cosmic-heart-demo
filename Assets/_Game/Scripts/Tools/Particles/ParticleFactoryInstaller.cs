using Zenject;

namespace CosmicHeart.Tools.Particles
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