using System;
using System.Collections;
using UnityEngine;

namespace CosmicHeart.Tools.Static
{
    public static class MonoExtensions
    {
        public static Coroutine WaitForAction(this MonoBehaviour mono, float seconds, Action callback)
        {
            return mono.StartCoroutine(WaitForActionRoutine(seconds, callback));
        }

        public static Coroutine WaitFixedUpdateForAction(this MonoBehaviour mono, Action callback)
        {
            return mono.StartCoroutine(WaitFixedUpdateForActionRoutine(callback));
        }

        private static IEnumerator WaitForActionRoutine(float seconds, Action callback)
        {
            for (float t = 0f; t < seconds; t += Time.deltaTime)
            {
                yield return null;
            }

            callback?.Invoke();
        }

        private static IEnumerator WaitFixedUpdateForActionRoutine(Action callback)
        {
            yield return new WaitForFixedUpdate();
            callback?.Invoke();
        }
    }
}