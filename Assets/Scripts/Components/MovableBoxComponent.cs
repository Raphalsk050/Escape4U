using System;
using UnityEngine;
using UnityEngine.Events;

namespace escape4u
{
    public class MovableBoxComponent : InteractableComponent
    {
        private float _initialInteractionDistance;
        private Vector3 _interactionForwardVector;
        protected override void ExecuteAction_internal()
        {
            base.ExecuteAction_internal();
        }

        private void Update()
        {
            if (GetInteractableState() == InteractableState.INTERACTING && Instigator && Activated)
            {
                var instigatorTransform = Instigator.transform;
                var boundingBox = gameObject.GetComponent<Collider2D>().bounds;
                var boundsSize = boundingBox.size;
                
                var newPosition = instigatorTransform.position + _interactionForwardVector * (_initialInteractionDistance);
                var currentPosition = transform.position;
                transform.position = new Vector3(newPosition.x, currentPosition.y, currentPosition.z);
            }
        }

        public override void OnBeginInteract(Interactor instigator)
        {
            base.OnBeginInteract(instigator);
            _initialInteractionDistance = Vector2.Distance(instigator.transform.position, transform.position) * 1.1f;
            var instigatorTransform = instigator.gameObject.transform;
            _interactionForwardVector = ((transform.position.x - instigator.transform.position.x) * instigatorTransform.right).normalized;
            //_interactionForwardVector = instigator.InteractorLocation * instigatorTransform.right;
        }

        public override void OnFinishInteract()
        {
            base.OnFinishInteract();
        }
    }
}