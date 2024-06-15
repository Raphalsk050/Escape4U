using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace escape4u.Tasks
{
    public class PatrolTask : MonoBehaviour, IBehaviorTask<MovementDelegate>
    {
        public ContactFilter2D contactFilter2D;
        public float distanceToCheckObstacles;
        public MovementDelegate movementDelegate;
        private Vector2 _movementSpeed = Vector2.zero;
        private Coroutine _movementRoutine;
        private Vector2 _lastDirection = Vector2.right;
        private List<RaycastHit2D> _rightHits = new List<RaycastHit2D>();
        private List<RaycastHit2D> _leftHits = new List<RaycastHit2D>();
        private delegate void SurfaceHitDelegate();
        
        //when this variable is false, the character goes to the left, and right otherwise
        private bool _movementMask;
        
        private SurfaceHitDelegate _surfaceHitDelegate;
        
        public void StartTask(MovementDelegate taskDelegate)
        {
            _movementMask = true;
            movementDelegate = taskDelegate;
            _movementRoutine = StartCoroutine(PatrolRoutine(movementDelegate));
        }

        public void FinishTask()
        {
            movementDelegate.Invoke(Vector2.zero);
            StopCoroutine(_movementRoutine);
        }
        
        IEnumerator PatrolRoutine(MovementDelegate movementDelegate)
        {
            while(true)
            {
                yield return new WaitForSeconds(1f);
                _movementSpeed = DecideDirectionToMove();
                movementDelegate.Invoke(_movementSpeed);
                Func<bool> surfaceCollision = CollideWithSurface;
                yield return new WaitUntil(surfaceCollision);
                movementDelegate.Invoke(Vector2.zero);
            }
        }
        
        private Vector2 DecideDirectionToMove()
        {
            var characterPosition = transform.position;
            Physics2D.Raycast(characterPosition, Vector2.right, contactFilter2D, _rightHits, distanceToCheckObstacles);
            Physics2D.Raycast(characterPosition, Vector2.left, contactFilter2D, _leftHits, distanceToCheckObstacles);

            if (_rightHits.Count > 0)
            {
                _lastDirection = Vector2.left;
                Debug.Log("right collider!");
                return _lastDirection;
            }
            if(_leftHits.Count > 0)
            {
                _lastDirection = Vector2.right;
                Debug.Log("left collider!");
                return _lastDirection;
            }
            
            return _lastDirection;
        }

        private bool CollideWithSurface()
        {
            var characterPosition = transform.position;
            Physics2D.Raycast(characterPosition, Vector2.right, contactFilter2D, _rightHits, distanceToCheckObstacles);
            Physics2D.Raycast(characterPosition, Vector2.left, contactFilter2D, _leftHits, distanceToCheckObstacles);
            
            
            if ((_movementMask && _rightHits.Count > 0) || (!_movementMask && _leftHits.Count > 0))
            {
                _movementMask = !_movementMask;
                return true;
            }

            return false;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            var characterPosition = (Vector2)transform.position;
            var rightDirection = Vector2.right * distanceToCheckObstacles + characterPosition;
            var leftDirection = Vector2.left * distanceToCheckObstacles + characterPosition;
            Gizmos.DrawLine(characterPosition, rightDirection);
            Gizmos.DrawLine(characterPosition, leftDirection);
        }
#endif
    }
}