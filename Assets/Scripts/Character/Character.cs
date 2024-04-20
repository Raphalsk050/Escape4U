using System;
using Unity.Mathematics;
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
        [SerializeField] protected float jumpForce = 430f;
        private Vector2 _movementSpeed;
        private float _currentMovementSpeed = 0f;
        private Rigidbody2D _rig;

        private float _verticalSpeed;

        protected virtual void Awake()
        {
            interactWithObject = new UnityEvent();
            _rig = GetComponent<Rigidbody2D>();
            _currentMovementSpeed = walkSpeed;
            _rig.gravityScale = 1;
        }

        protected virtual void FixedUpdate()
        {
            _movementSpeed.y = _rig.velocityY;
            _rig.velocity = new Vector2(_movementSpeed.x * _currentMovementSpeed, _movementSpeed.y);
        }

        public void Move(Vector2 movementSpeed)
        {
            _verticalSpeed = movementSpeed.y;
            _movementSpeed.x = movementSpeed.x;

            /*if(movementSpeed.x > 0){
                transform.rotation = Quaternion.Euler(0,0,0);
            }

            else if(movementSpeed.x < 0){
                transform.rotation = Quaternion.Euler(0,180,0);
            }*/
        }

        public void Jump()
        {
            _rig.AddForceY(jumpForce, ForceMode2D.Impulse);
            Debug.Log("Jump");
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