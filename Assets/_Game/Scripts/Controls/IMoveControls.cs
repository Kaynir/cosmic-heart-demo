using System;
using UnityEngine;

namespace CosmicHeart.Controls
{
    public interface IMoveControls
    {
        event Action<Vector3> MovePerformed;
        event Action<Vector3> LookPerformed;
    }
}