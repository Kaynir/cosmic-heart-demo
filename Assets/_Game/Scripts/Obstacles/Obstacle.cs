using UnityEngine;
using Zenject;

namespace CosmicHeart.Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private Rigidbody body = null;

        public Rigidbody Body => body;

        public class Factory : PlaceholderFactory<Obstacle> { }
    }
}