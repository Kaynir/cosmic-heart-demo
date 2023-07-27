using System;
using CosmicHeart.Controls;
using CosmicHeart.Movement.Moveables;
using UnityEngine;

namespace CosmicHeart.Characters
{
    public class PlayerFacade : IDisposable
    {
        private IMoveable moveable;
        private IMoveControls moveControls;

        public PlayerFacade(IMoveable moveable,
                            IMoveControls moveControls)
        {
            this.moveable = moveable;
            this.moveControls = moveControls;

            moveControls.MovePerformed += OnMovePerformed;
            moveControls.LookPerformed += OnLookPerformed;
        }

        public void Dispose()
        {
            moveControls.MovePerformed -= OnMovePerformed;
            moveControls.LookPerformed -= OnLookPerformed;
        }

        private void OnLookPerformed(Vector3 lookDirection)
        {
            moveable.SetLookDirection(lookDirection);
        }

        private void OnMovePerformed(Vector3 moveDirection)
        {
            moveable.SetMoveDirection(moveDirection);
        }
    }
}