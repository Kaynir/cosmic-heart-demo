using CosmicHeart.Controls;
using UnityEngine;
using Zenject;

namespace CosmicHeart.Interactions
{
    public class InteractionSeeker : MonoBehaviour
    {
        [SerializeField] private Transform sourcePoint = null;
        [SerializeField] private RaycastConfig raycastConfig = null;

        public IActionControls Actions { get; private set; }
        
        private IInteractable activeInteractable;

        [Inject]
        public void Construct(IActionControls actionControls)
        {
            Actions = actionControls;
        }

        private void Update()
        {
            SearchForInteractable();
        }

        private void SearchForInteractable()
        {
            if (!raycastConfig.TryRaycast(sourcePoint, out RaycastHit hit))
            {
                ClearActiveInteractable();
                return;
            }

            if (!hit.transform.TryGetComponent(out IInteractable interactable))
            {
                ClearActiveInteractable();
                return;
            }

            if (activeInteractable == interactable) return;

            SetActiveInteractable(interactable);
        }

        private void SetActiveInteractable(IInteractable interactable)
        {
            activeInteractable?.ExitInteraction();
            activeInteractable = interactable;
            activeInteractable.EnterInteraction(this);
        }

        private void ClearActiveInteractable()
        {
            activeInteractable?.ExitInteraction();
            activeInteractable = null;
        }
    }
}