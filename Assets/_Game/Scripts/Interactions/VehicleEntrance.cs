using CosmicHeart.Controls;
using CosmicHeart.Interactions;
using UnityEngine;

namespace CosmicHeart.Characters
{
    public class VehicleEntrance : MonoBehaviour, IInteractable
    {
        [SerializeField] private Vehicle vehicle = null;

        private InteractionSeeker driver;

        private void OnDestroy()
        {
            ExitInteraction();
        }

        public void EnterInteraction(InteractionSeeker seeker)
        {
            driver = seeker;
            driver.Actions.ActionPerformed += HandleDriverAction;
        }

        public void ExitInteraction()
        {
            if (!driver) return;

            driver.Actions.ActionPerformed -= HandleDriverAction;
            driver = null;
        }

        private void HandleDriverAction(InputActionType actionType)
        {
            if (actionType != InputActionType.Interaction) return;

            if (vehicle.IsDriving) vehicle.Exit();
            else vehicle.Enter(driver.transform);
        }
    }
}