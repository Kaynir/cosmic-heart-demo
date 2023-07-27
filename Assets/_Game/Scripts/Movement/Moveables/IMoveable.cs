using UnityEngine;

namespace CosmicHeart.Movement.Moveables
{
    public interface IMoveable
    {
        float MoveSpeed { get; set; }

        void SetLookDirection(Vector3 lookDirection);
        void SetMoveDirection(Vector3 moveDirection);
    }
}