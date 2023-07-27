using UnityEngine;

namespace CosmicHeart.Weapons.Aiming
{
    public abstract class AimingModule : MonoBehaviour
    {
        public abstract Transform GetTarget(Transform origin);
    }
}