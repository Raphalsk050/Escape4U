using System;
using System.Collections;
using System.Collections.Generic;
using escape4u.Tasks;
using UnityEngine;

namespace escape4u
{
    public class AIController : Controller
    {
        private IBehaviorTask<MovementDelegate> _movementTask;
        private MovementDelegate _moveDelegate;
        
        private void Awake()
        {
            PossessCharacter(possessedCharacter);
            _moveDelegate = possessedCharacter.Move;
            _movementTask = GetComponent<IBehaviorTask<MovementDelegate>>();
            _movementTask.StartTask(_moveDelegate);
        }

        private void Update()
        {
        }

        public override void PossessCharacter(Character characterToPosses)
        {
            base.PossessCharacter(characterToPosses);
            //_movementRoutine = StartCoroutine(PatrolRoutine());
            
        }

        protected override void Jump()
        {
            base.Jump();
        }
    }
}