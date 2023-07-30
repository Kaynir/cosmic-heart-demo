using CosmicHeart.Tools.Static;
using UnityEngine;

namespace CosmicHeart.Obstacles
{
    [CreateAssetMenu(menuName = AssetMenuConsts.OBSTACLE_CONFIG_PATH + "Obstacle Config")]
    public class ObstacleConfig : ScriptableObject
    {
        [SerializeField, Min(1f)] private float baseMass = 5f;
        [SerializeField, Min(1)] private int baseHealth = 10;
        [SerializeField, Range(0f, 360f)] private float maxRotation = 180f;
        [SerializeField] private AnimationCurve scaleCurve = AnimationCurve.EaseInOut(0f, .5f, 1f, 3f);

        public Settings GetSettings()
        {
            float randomValue = Random.value;
            float randomScale = scaleCurve.Evaluate(randomValue);

            return new Settings()
            {
                mass = randomScale * baseMass,
                health = (int)(randomScale * baseHealth),
                rotation = Quaternion.Euler(Random.insideUnitSphere * maxRotation),
                localScale = Vector3.one * randomScale
            };
        }

        public struct Settings
        {
            public float mass;
            public int health;
            public Quaternion rotation;
            public Vector3 localScale;
        }
    }
}