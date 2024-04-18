using UnityEngine;
using UnityEngine.Events;

namespace escape4u
{
    public class InteractableComponent : Component, IInteractable
    {
        public UnityEvent OnStartInteract = new UnityEvent();
        public UnityEvent OnEndInteract = new UnityEvent();

        protected Interactor Instigator;
        protected InteractableState CurrentInteractableState;

        protected override void ExecuteAction_internal()
        {
            base.ExecuteAction_internal();
        }
        
        public virtual void OnBeginInteract(Interactor instigator)
        {
            Instigator = instigator;
            ChangeInteractableState(InteractableState.INTERACTING);
            OnStartInteract.Invoke();
        }

        public virtual void OnFinishInteract()
        {
            OnEndInteract.Invoke();
            ChangeInteractableState(InteractableState.IDLE);
        }

        public InteractableState GetInteractableState()
        {
            return CurrentInteractableState;
        }

        protected void ChangeInteractableState(InteractableState newState){
            CurrentInteractableState = newState;
        }
    }
}