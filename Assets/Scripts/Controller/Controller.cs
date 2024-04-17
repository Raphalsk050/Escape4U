using UnityEngine;

namespace escape4u
{
    public class Controller : MonoBehaviour
    {
        public Character possessedCharacter;
        
        protected virtual Actor GetOwner()
        {
            return gameObject.GetComponent<Actor>();
        }

        public virtual void PossessCharacter(Character characterToPosses)
        {
            possessedCharacter = characterToPosses;
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