using UnityEngine;
using UnityEngine.Events;

namespace escape4u
{
    public class Controller : MonoBehaviour
    {
        public UnityEvent<bool> OnCrouch;
        public UnityEvent<bool> OnInteract;
        public UnityEvent<bool> OnJump;
        public UnityEvent<bool> onSprint;
        
        public Character possessedCharacter;
        
        protected virtual Actor GetOwner()
        {
            return gameObject.GetComponent<Actor>();
        }

        public virtual void PossessCharacter(Character characterToPosses)
        {
            possessedCharacter = characterToPosses;
            possessedCharacter.OnPossessed(this);
        }
        
        protected virtual void Move()
        {
            
        }

        protected virtual void Jump()
        {
            
        }

        protected virtual void Interact()
        {
            
        }

        protected virtual void Crouch()
        {
            
        }

        protected virtual void Sprint()
        {
            
        }
    }
}