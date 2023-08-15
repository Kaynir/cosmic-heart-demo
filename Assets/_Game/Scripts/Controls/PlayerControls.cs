using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace CosmicHeart.Controls
{
    public class PlayerControls : MonoBehaviour, IMoveControls, IActionControls
    {
        public event Action<InputActionType> ActionPerformed;
        public event Action<InputActionType> ActionCanceled;

        public Vector3 MoveInput { get; private set; }
        public Vector3 LookInput { get; private set; }

        private Dictionary<InputActionType, bool> actions;

        private void Awake()
        {
            MoveInput = Vector3.zero;
            LookInput = Vector3.zero;

            actions = new Dictionary<InputActionType, bool>();
        }

        public bool GetActionState(InputActionType type)
        {
            return actions.TryGetValue(type, out bool performed) && performed;
        }

        private void SetAction(InputActionType type, CallbackContext context)
        {
            actions[type] = context.performed;
            
            if (context.performed) ActionPerformed?.Invoke(type);
            if (context.canceled) ActionCanceled?.Invoke(type);
        }

        #region Input System Callbacks
        public void OnMovePerformed(CallbackContext context)
        {
            MoveInput = context.ReadValue<Vector2>();
        }

        public void OnLookPerformed(CallbackContext context)
        {
            LookInput = context.ReadValue<Vector2>();
        }

        public void OnMainWeaponShotPerformed(CallbackContext context)
        {
            SetAction(InputActionType.MainWeapon, context);
        }

        public void OnExtraWeaponShotPerformed(CallbackContext context)
        {
            SetAction(InputActionType.ExtraWeapon, context);
        }

        public void OnInteractionPerformed(CallbackContext context)
        {
            SetAction(InputActionType.Interaction, context);
        }
        #endregion
    }
}