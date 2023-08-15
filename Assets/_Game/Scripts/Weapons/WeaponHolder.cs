using System;
using System.Collections.Generic;
using CosmicHeart.Controls;
using UnityEngine;
using Zenject;

namespace CosmicHeart.Weapons
{
    public class WeaponHolder : MonoBehaviour
    {
        [SerializeField] private List<WeaponSlot> weaponSlots = new();

        private IActionControls controls;

        [Inject]
        public void Construct(IActionControls actionControls)
        {
            controls = actionControls;
        }

        private void Update()
        {
            foreach (WeaponSlot slot in weaponSlots)
            {
                if (!controls.GetActionState(slot.actionType)) continue;
                slot.weapon.Shoot();
            }
        }

        [Serializable]
        private struct WeaponSlot
        {
            public Weapon weapon;
            public InputActionType actionType;
        }
    }
}