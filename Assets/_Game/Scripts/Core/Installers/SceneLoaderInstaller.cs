using Kaynir.SceneExtension;
using UnityEngine;
using Zenject;

namespace CosmicHeart.Core.Installers
{
    public class SceneLoaderInstaller : MonoInstaller
    {
        [SerializeField] private SceneLoader sceneLoader = null;

        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>()
                     .ToSelf()
                     .FromInstance(sceneLoader)
                     .AsSingle();
        }
    }
}