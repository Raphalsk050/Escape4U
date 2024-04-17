using UnityEngine;

namespace escape4u
{
    public class Actor : MonoBehaviour
    {
        public Vector2 GetActorLocation()
        {
            return transform.position;
        }

        public void SetActorLocation(Vector2 newPosition)
        {
            transform.position = newPosition;
        }
    }
}