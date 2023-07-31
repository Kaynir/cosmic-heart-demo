using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace CosmicHeart.Controls
{
    public class PlayerControls : IMoveControls, IWeaponControls
    {
        public event Action<Vector3> MovePerformed;
        public event Action<Vector3> LookPerformed;

        public event Action<int, bool> ShotPerformed;

        private PlayerInputActions inputActions;

        public PlayerControls(PlayerInputActions actions)
        {
            inputActions = actions;
            inputActions.Character.Enable();
            inputActions.Character.Move.performed += OnMovePerformed;
            inputActions.Character.Look.performed += OnLookPerformed;
            inputActions.Character.Weapon_1.performed += OnShotPerformed_1;
            inputActions.Character.Weapon_2.performed += OnShotPerformed_2;
        }

        private void OnMovePerformed(CallbackContext context)
        {
            MovePerformed?.Invoke(context.ReadValue<Vector2>());
        }

        private void OnLookPerformed(CallbackContext context)
        {
            LookPerformed?.Invoke(context.ReadValue<Vector2>());
        }

        private void OnShotPerformed_1(CallbackContext context)
        {
            ShotPerformed?.Invoke(0, context.ReadValueAsButton());
        }

        private void OnShotPerformed_2(CallbackContext context)
        {
            ShotPerformed?.Invoke(1, context.ReadValueAsButton());
        }
    }
}