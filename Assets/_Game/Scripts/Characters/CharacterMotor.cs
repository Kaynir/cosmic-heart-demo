using CosmicHeart.Controls;
using CosmicHeart.Movement.Moveables;
using UnityEngine;
using Zenject;

namespace CosmicHeart.Characters
{
    public class CharacterMotor : MonoBehaviour
    {
        private IMoveable moveable;
        private IMoveControls moveControls;

        [Inject]
        public void Construct(IMoveControls moveControls)
        {
            this.moveControls = moveControls;
            moveable = GetComponent<IMoveable>();
        }

        private void Update()
        {
            moveable.SetMoveDirection(moveControls.MoveInput);
            moveable.SetLookDirection(moveControls.LookInput);
        }

        private void OnDisable()
        {
            moveable.ResetVelocity();
        }
    }
}
