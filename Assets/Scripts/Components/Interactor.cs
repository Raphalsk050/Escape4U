using System;
using UnityEngine;

namespace escape4u
{
    public class Interactor : Component
    {
        public float InteractorRadius = 1f;
        public float InteractionDistance { get => _interactionDistance; }


        private float _interactionDistance = 0.2f;
        private Collider2D[] _colliders;

        protected override void ExecuteAction_internal()
        {
            base.ExecuteAction_internal();
            _colliders = Physics2D.OverlapCircleAll(GetOwner().GetActorLocation(), InteractorRadius);
            
            foreach(var collider in _colliders){
                if(collider.gameObject.GetComponent<IInteractable>() != null){
                    var interactable = collider.gameObject.GetComponent<IInteractable>();
                    switch(interactable.GetInteractableState()){
                        case InteractableState.IDLE:
                            interactable.OnBeginInteract(this);
                        break;
                        case InteractableState.INTERACTING:
                            interactable.OnFinishInteract();
                        break;
                    }
                    Debug.Log("Interacting with " + collider.gameObject.name);
                }
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (!GetOwner()) return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(GetOwner().GetActorLocation(), InteractorRadius);
        }
    }
#endif
}