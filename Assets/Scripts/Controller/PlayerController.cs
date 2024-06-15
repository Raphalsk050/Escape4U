using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace escape4u
{
    public class PlayerController : Controller
    {
        private InputSystem_Actions _actionMap;
        private Vector2 _movementSpeed = Vector2.zero;
        private float _verticalInput;
        private Actor _owner;
        private bool _receivingInput;
        private bool _crouch;

        public bool GetCrouch
        {
            get => _crouch;
        }

        private void Awake()
        {
            _owner = GetOwner();
            _actionMap = new InputSystem_Actions();
            _actionMap.Enable();
            
            _actionMap.Player.Move.performed += Move;
            _actionMap.Player.Jump.performed += _ => Jump();
            _actionMap.Player.Crouch.performed += _ => Crouch();
            _actionMap.Player.Interact.performed += _ => Interact();
            _actionMap.Player.Sprint.performed += Sprint;
        }
        
        private void Move(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            _movementSpeed = value;
            possessedCharacter.Move(_movementSpeed);
        }

        protected override void Jump()
        {
            possessedCharacter.Jump();
        }

        protected override void Crouch()
        {
            _crouch = !_crouch;
            possessedCharacter.Crouch(_crouch);
            OnCrouch.Invoke(_crouch);
        }

        protected override void Interact()
        {
            possessedCharacter.Interact();
        }

        private void Sprint(InputAction.CallbackContext context)
        {
            var sprinting = context.ReadValue<float>();
            onSprint.Invoke(sprinting > 0);
            possessedCharacter.Sprint(sprinting > 0);
        }
    }
}