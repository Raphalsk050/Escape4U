using System;
using UnityEngine;
using UnityEngine.Events;

namespace escape4u
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : Actor
    {
        public UnityEvent interactWithObject;
        
        [SerializeField] protected float walkSpeed = 6f;
        [SerializeField] protected float sprintModifier = 1.5f;
        private Vector2 _movementSpeed;
        private float _currentMovementSpeed = 0f;
        private Rigidbody2D _rig;

        private float _verticalSpeed;

        protected virtual void Awake()
        {
            interactWithObject = new UnityEvent();
            _rig = GetComponent<Rigidbody2D>();
            _currentMovementSpeed = walkSpeed;
            _rig.gravityScale = 0;
        }

        protected virtual void FixedUpdate()
        {
            _rig.velocity = _movementSpeed * _currentMovementSpeed;
        }

        public void Move(Vector2 movementSpeed)
        {
            _verticalSpeed = movementSpeed.y;
            _movementSpeed.x = movementSpeed.x;
            _movementSpeed.y = _rig.velocityY;

            if(movementSpeed.x > 0){
                transform.rotation = Quaternion.Euler(0,0,0);
            }

            else if(movementSpeed.x < 0){
                transform.rotation = Quaternion.Euler(0,180,0);
            }
        }

        public void Jump()
        {
            Debug.Log("Jump!");
        }

        public void Crouch()
        {
            Debug.Log("Crouch!");
        }

        public void Interact()
        {
            interactWithObject.Invoke();
        }

        public void Sprint(bool sprinting)
        {
            _currentMovementSpeed = sprinting ? walkSpeed * sprintModifier : walkSpeed;
        }
    }
}