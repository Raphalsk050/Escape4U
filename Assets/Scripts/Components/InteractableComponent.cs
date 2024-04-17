using UnityEngine;

namespace escape4u
{
    public class InteractableComponent : Component, IInteractable
    {
        protected override void ExecuteAction_internal()
        {
            base.ExecuteAction_internal();
            
        }
        
        public void OnBeginInteract()
        {
            
        }

        public void OnFinishInteract()
        {
            
        }
    }
}