using Kaynir.SceneExtension;
using UnityEngine;
using Zenject;

namespace CosmicHeart.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject] private SceneLoader sceneLoader;

        private void Start()
        {   
            sceneLoader.LoadSingle((int)MainScenes.Galaxy,
                                   (int)MainScenes.MainMenu);
        }
    }
}