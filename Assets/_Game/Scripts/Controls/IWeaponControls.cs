using System;

namespace CosmicHeart.Controls
{
    public interface IWeaponControls
    {
        event Action<int> ShotPerformed;
    }
}