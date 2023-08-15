using UnityEngine;

namespace CosmicHeart.Controls
{
    public interface IMoveControls
    {
        Vector3 MoveInput { get; }
        Vector3 LookInput { get; }
    }
}