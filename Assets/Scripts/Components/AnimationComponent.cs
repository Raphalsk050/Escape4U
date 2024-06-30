using System;
using UnityEngine;
using UnityEngine.Events;

namespace escape4u{
    public class AnimationComponent : Component
    {
        [SerializeField] private string _crouchParameter;
        [SerializeField] private string _speedParameter;
        [SerializeField] private string _sprintParameter;
        [SerializeField] private string _interactParameter;
        [SerializeField] private string _pushParameter;
        [SerializeField] private string _jumpParameter;
        
        public Controller controller;
        private CharacterSubStates _characterSubState;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private Character _possessedCharacter;
        
        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            _possessedCharacter = controller.possessedCharacter;
            controller.OnCrouch.AddListener(Crouch);
            controller.onSprint.AddListener(Sprint);
            controller.OnInteract.AddListener(Interact);
            _possessedCharacter.characterSpeedChanged.AddListener(PlayerVelocity);
        }

        private void Crouch(bool value)
        {
            _animator.SetBool(_crouchParameter, value);
        }

        private void PlayerVelocity(float value)
        {
            if (!_animator.GetBool(_interactParameter))
            {
                _spriteRenderer.flipX = value != 0 ? value < 0 : _spriteRenderer.flipX;
            }
            else
            {
                float playerDirection = _spriteRenderer.flipX ? 1.0f : -1.0f;
                _animator.SetBool(_pushParameter, value != 0 ? value * playerDirection < 0 : _animator.GetBool(_pushParameter));
            }
            _animator.SetFloat(_speedParameter, Mathf.Abs(value));
        }

        private void Sprint(bool value)
        {
            _animator.SetBool(_sprintParameter, value);
        }
        
        private void Interact(bool value)
        {
            _animator.SetBool(_interactParameter, value);
        }
    }
}