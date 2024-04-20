using System;
using UnityEngine;
using UnityEngine.Events;

namespace escape4u
{
    public class CarriableComponent : InteractableComponent
    {
        protected override void ExecuteAction_internal()
        {
            base.ExecuteAction_internal();
        }

        private void Update()
        {
            
        }

        public override void OnBeginInteract(Interactor instigator)
        {
            base.OnBeginInteract(instigator);
            var instigadorTransform = instigator.gameObject.transform;
            transform.SetParent(instigadorTransform, true);
        }

        public override void OnFinishInteract()
        {
            base.OnFinishInteract();
            transform.SetParent(null, true);
        }
    }
}