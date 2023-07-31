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

        private bool[] weaponStates;

        private void Awake()
        {
            weaponStates = new bool[weapons.Count];
        }

        private void OnEnable()
        {
            controls.ShotPerformed += SetWeaponShootState;
        }

        private void OnDisable()
        {
            controls.ShotPerformed -= SetWeaponShootState;
        }

        private void Update()
        {
            for (int i = 0; i < weaponStates.Length; i++)
            {
                if (!weaponStates[i]) continue;
                
                weapons[i].Shoot();
            }
        }

        private void SetWeaponShootState(int index, bool enabled)
        {
            if (!IsWeaponAssigned(index)) return;
            
            weaponStates[index] = enabled;
        }

        private bool IsWeaponAssigned(int index)
        {
            if (index < weapons.Count) return true;

            Debug.Log($"Weapon [{index}] not assigned.");
            return false;
        }
    }
}