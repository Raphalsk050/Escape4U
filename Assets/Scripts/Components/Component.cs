using System;
using UnityEngine;

namespace escape4u
{
    public class Component : MonoBehaviour
    {
        public bool startActivated = true;
        protected bool Activated = false;
        private Actor _owner;

        protected void Awake()
        {
            _owner = GetComponent<Actor>();
            if(startActivated)
                Activate();
        }

        public void Activate()
        {
            Activated = true;
        }

        public void Deactivate()
        {
            Activated = false;
        }

        public void ExecuteAction()
        {
            if (Activated)
                ExecuteAction_internal();
        }

        public Actor GetOwner()
        {
            return _owner;
        }
        
        protected virtual void ExecuteAction_internal()
        {
            
        }
    }
}