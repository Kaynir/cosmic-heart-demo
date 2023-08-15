using System;

namespace CosmicHeart.Controls
{
    public interface IActionControls
    {
        event Action<InputActionType> ActionPerformed;
        event Action<InputActionType> ActionCanceled;

        bool GetActionState(InputActionType type);
    }
}