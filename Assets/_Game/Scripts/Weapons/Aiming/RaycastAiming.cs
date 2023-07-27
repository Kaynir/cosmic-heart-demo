using UnityEngine;

namespace CosmicHeart.Weapons.Aiming
{
    public class RaycastAiming : AimingModule
    {
        [SerializeField] private RaycastConfig config = null;

        public override Transform GetTarget(Transform origin)
        {
            config.TryRaycast(origin.position,
                              origin.forward,
                              out RaycastHit hit);
            
            return hit.transform;
        }
    }
}