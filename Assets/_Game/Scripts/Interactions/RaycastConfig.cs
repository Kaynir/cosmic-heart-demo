using CosmicHeart.Tools.Static;
using UnityEngine;

namespace CosmicHeart.Interactions
{
    [CreateAssetMenu(menuName = AssetMenuConsts.WEAPON_CONFIG_PATH + "Raycast Config")]
    public class RaycastConfig : ScriptableObject
    {
        [SerializeField] private float maxDistance = 100f;
        [SerializeField] private LayerMask layers = 0;

        public bool TryRaycast(Vector3 origin, Vector3 direction, out RaycastHit hit)
        {
            return Physics.Raycast(origin, direction, out hit, maxDistance, layers);
        }

        public bool TryRaycast(Transform originPoint, out RaycastHit hit)
        {
            return TryRaycast(originPoint.position, originPoint.forward, out hit);
        }
    }
}