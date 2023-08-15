namespace CosmicHeart.Interactions
{
    public interface IInteractable
    {
        void EnterInteraction(InteractionSeeker seeker);
        void ExitInteraction();
    }
}