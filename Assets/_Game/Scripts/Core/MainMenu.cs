using Kaynir.SceneExtension.Tools;
using UnityEngine;

namespace CosmicHeart.Core
{
    public class MainMenu : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.visible = true;
        }

        public void PlayGame()
        {
            Cursor.visible = false;
            SceneHelper.LoadAdditive((int)MainScenes.PlayerSpaceship);
            SceneHelper.Unload((int)MainScenes.MainMenu);
        }
    }
}