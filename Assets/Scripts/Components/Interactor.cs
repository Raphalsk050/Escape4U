using System;
using UnityEngine;

namespace escape4u
{
    public class Interactor : Component
    {
        public float InteractorRadius = 1f;

        protected override void ExecuteAction_internal()
        {
            base.ExecuteAction_internal();

            Debug.Log("Interacting with object");
            
        }

        private void OnDrawGizmos()
        {
            if (!GetOwner()) return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(GetOwner().GetActorLocation(), InteractorRadius);
        }
    }
}