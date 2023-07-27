using UnityEngine;

namespace CosmicHeart.Movement.Launchables
{
    public class VelocityLaunchable : MonoBehaviour, ILaunchable
    {
        [SerializeField] private Rigidbody body = null;

        public void Lauch(LaunchSettings settings)
        {
            Vector3 direction = GetDirection(settings.origin, settings.target);
            body.rotation = Quaternion.LookRotation(direction);
            body.velocity = direction * settings.force;
        }

        private Vector3 GetDirection(Transform origin, Transform target)
        {
            return target
            ? (target.position - origin.position).normalized
            : origin.forward;
        }
    }
}