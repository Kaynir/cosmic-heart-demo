using UnityEngine;
using UnityEngine.SceneManagement;

namespace CosmicHeart.Core
{
    public class MainMenu : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.visible = true;
        }

        // TODO: перенести загрузку сцен в SceneLoader
        public void PlayGame()
        {
            Cursor.visible = false;
            SceneManager.LoadSceneAsync((int)MainScenes.PlayerSpaceship, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync((int)MainScenes.MainMenu);
        }
    }
}