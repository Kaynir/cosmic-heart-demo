using UnityEngine;
using Zenject;

namespace CosmicHeart.Obstacles
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [Header("Spawn Settings:")]
        [SerializeField] private Vector2Int countRange = Vector2Int.one;
        [SerializeField] private float maxRadius = 5f;

        [Header("Overlap Check:")]
        [SerializeField] private LayerMask overlapMask = 0;
        [SerializeField] private float overlapRadius = 2.5f;
        [SerializeField] private int maxCheckAttempts = 50;

        [Inject] private Obstacle.Factory factory;

        private void Start() => GenerateObstacles();

        private void GenerateObstacles()
        {
            int count = Random.Range(countRange.x, countRange.y + 1);
            Vector3 originPosition = transform.position;

            for (int i = 0; i < count; i++)
            {
                CreateObstacle(originPosition);
            }
        }

        private void CreateObstacle(Vector3 position)
        {
            for (int i = 0; i < maxCheckAttempts; i++)
            {
                position += Random.insideUnitSphere * maxRadius;

                if (!Physics.CheckSphere(position, overlapRadius, overlapMask))
                {
                    Obstacle obstacle = factory.Create();
                    obstacle.transform.position = position;
                    break;
                }
            }
        }
    }
}