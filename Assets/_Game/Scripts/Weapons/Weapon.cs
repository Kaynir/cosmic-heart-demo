using System.Collections.Generic;
using CosmicHeart.Tools.Static;
using CosmicHeart.Weapons.Aiming;
using CosmicHeart.Weapons.Shooting;
using Kaynir.Audio;
using UnityEngine;

namespace CosmicHeart.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private List<Transform> firePoints = new List<Transform>();

        [Header("Aiming Settings:")]
        [SerializeField] private Transform aimingOrigin = null;
        [SerializeField] private AimingModule aimingModule = null;
        
        [Header("Shooting Settings:")]
        [SerializeField] private float shootingCooldown = 5f;
        [SerializeField] private ShootingModule shootingModule = null;
        [SerializeField] private SoundPlayer shootingSound = null;

        private bool isCooldown;

        public void Shoot()
        {
            if (isCooldown) return;

            Transform target = aimingModule.GetTarget(aimingOrigin);

            firePoints.ForEach(point =>
            {
                shootingModule.ExecuteShot(point, target);
            });

            shootingSound.PlayOneShot();
            SetCooldown();
        }

        private void SetCooldown()
        {
            isCooldown = true;
            this.WaitForAction(shootingCooldown, () =>
            {
                isCooldown = false;
            });
        }
    }
}