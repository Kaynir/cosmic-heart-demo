using System.Collections.Generic;
using CosmicHeart.Controls;
using UnityEngine;
using Zenject;

namespace CosmicHeart.Weapons
{
    public class WeaponHolder : MonoBehaviour
    {
        [SerializeField] private List<Weapon> weapons = new List<Weapon>();

        [Inject] private IWeaponControls controls;

        private void OnEnable()
        {
            controls.ShotPerformed += ShootWeapon;
        }

        private void OnDisable()
        {
            controls.ShotPerformed -= ShootWeapon;
        }

        private void ShootWeapon(int index)
        {
            GetWeapon(index)?.Shoot();
        }

        private Weapon GetWeapon(int index)
        {
            if (index < weapons.Count)
            {
                return weapons[index];
            }

            Debug.Log($"Weapon [{index}] not assigned.");
            return null;
        }
    }
}