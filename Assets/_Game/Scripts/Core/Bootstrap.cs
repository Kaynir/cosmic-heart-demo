using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CosmicHeart.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private List<MainScenes> startScenes = new List<MainScenes>();

        private IEnumerator Start()
        {
            yield return LoadStartScenesRoutine();
        }

        // TODO: перенести загрузку сцен в SceneLoader
        private IEnumerator LoadStartScenesRoutine()
        {
            var operations = startScenes.Select((scene, i) =>
            {
                var mode = i == 0 ? LoadSceneMode.Single : LoadSceneMode.Additive;
                var op = SceneManager.LoadSceneAsync((int)scene, mode);
                op.allowSceneActivation = false;
                return op;
            }).ToList();

            while (operations.All(op => op.progress < .9f))
            {
                yield return null;
            }

            foreach (var op in operations)
            {
                op.allowSceneActivation = true;
            }
        }
    }
}