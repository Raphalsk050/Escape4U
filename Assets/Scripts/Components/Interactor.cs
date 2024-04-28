using System;
using UnityEngine;

namespace escape4u
{
    public class Interactor : Component
    {
        public float InteractorRadius = 1f;
        public float InteractionDistance { get => _interactionDistance; }
        
        [HideInInspector] public int InteractorLocation;
        private float _interactionDistance = 0.2f;
        private Collider2D[] _colliders;
        private SpriteRenderer _spriteRenderer;
        private PlayerController _controller;

        public void SetController(PlayerController controller)
        {
            _controller = controller;
        }
        
        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        protected override void ExecuteAction_internal()
        {
            base.ExecuteAction_internal();
            _colliders = Physics2D.OverlapCircleAll(GetOwner().GetActorLocation(), InteractorRadius);
            InteractorLocation = _spriteRenderer.flipX ? -1 : 1;
            foreach(var collider in _colliders){
                if(collider.gameObject.GetComponent<IInteractable>() != null){
                    var interactable = collider.gameObject.GetComponent<IInteractable>();
                    switch(interactable.GetInteractableState()){
                        case InteractableState.IDLE:
                            interactable.OnBeginInteract(this);
                            _controller.OnInteract.Invoke(true);
                        break;
                        case InteractableState.INTERACTING:
                            interactable.OnFinishInteract();
                            _controller.OnInteract.Invoke(false);
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