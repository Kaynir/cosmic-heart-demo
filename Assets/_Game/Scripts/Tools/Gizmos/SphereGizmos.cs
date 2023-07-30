using UnityEngine;

namespace CosmicHeart.Tools.GizmosHelpers
{
    public class SphereGizmos : MonoBehaviour
    {
        [SerializeField] private float radius = 5f;
        [SerializeField] private Color color = Color.yellow;

        private void OnDrawGizmos()
        {
            Gizmos.color = color;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}