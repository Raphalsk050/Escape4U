namespace escape4u
{
    public enum InteractableState
    {
        IDLE,
        INTERACTING
    }

    public interface IInteractable
    {
        public void OnBeginInteract(Interactor instigator);
        public void OnFinishInteract();

        public InteractableState GetInteractableState();
    }
}