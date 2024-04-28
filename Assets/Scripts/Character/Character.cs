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
        public UnityEvent<float> characterSpeedChanged;
        
        [SerializeField] protected float walkSpeed = 6f;
        [SerializeField] protected float sprintModifier = 1.5f;
        [SerializeField] protected float crouchModifier = 0.5f;
        [SerializeField] protected float jumpForce = 810f;
        [SerializeField] protected LayerMask groundLayer;
        
        private Vector2 _movementSpeed;
        private float _currentMovementSpeed = 0f;
        private Rigidbody2D _rig;
        private bool _isGrounded;
        private float _verticalSpeed;
        private bool _crouched;
        private Controller _controller;
        
        public Controller GetController
        {
            get => _controller;
        }
        
        protected virtual void Awake()
        {
            interactWithObject = new UnityEvent();
            _rig = GetComponent<Rigidbody2D>();
            _currentMovementSpeed = walkSpeed;
            _rig.gravityScale = 3;
        }

        public void OnPossessed(Controller controller)
        {
            _controller = controller;
        }

        private void Update()
        {
            _isGrounded = _rig.IsTouchingLayers(groundLayer);
        }

        protected virtual void FixedUpdate()
        {
            _movementSpeed.y = _rig.velocityY;
            _rig.velocity = new Vector2(_movementSpeed.x * _currentMovementSpeed, _movementSpeed.y);

            characterSpeedChanged.Invoke(_rig.velocityX);
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
            if (!_isGrounded) return;
            _rig.AddForceY(jumpForce, ForceMode2D.Impulse);
            Debug.Log("Jump");
        }

        public void Crouch(bool value)
        {
            _crouched = value;
            _currentMovementSpeed = _crouched ? walkSpeed * crouchModifier : walkSpeed;
            Debug.Log("Crouch!");
        }

        public void Interact()
        {
            interactWithObject.Invoke();
        }

        public void Sprint(bool sprinting)
        {
            if(!_crouched)
                _currentMovementSpeed = sprinting ? walkSpeed * sprintModifier : walkSpeed;
        }
    }
}