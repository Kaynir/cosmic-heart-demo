using UnityEngine;

namespace CosmicHeart.Movement.Moveables
{
    public interface IMoveable
    {
        void SetLookDirection(Vector3 lookDirection);
        void SetMoveDirection(Vector3 moveDirection);
        void ResetVelocity();
    }
}