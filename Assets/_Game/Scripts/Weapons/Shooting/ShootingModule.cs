using UnityEngine;

namespace CosmicHeart.Weapons.Shooting
{
    public abstract class ShootingModule : MonoBehaviour
    {
        public abstract void ExecuteShot(Transform firePoint, Transform target);
    }
}