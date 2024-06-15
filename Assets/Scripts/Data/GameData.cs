
using UnityEngine;

namespace escape4u{
    public enum NormalStates{
        IDLE,
        WALKING,
        SPRINTING,
    }

    public enum CrouchStates{
        IDLECROUCHING,
        WALKCROUCHING,
    }

    public enum CarryingStates{
        IDLECARRYING,
        WALKCARRYING
    }

    public enum DragStates{
        IDLEDRAGGING,
        WALKDRAGGING
    }

    public enum CharacterSubStates{
        NORMAL,
        CROUCH,
        CARRING,
        DRAGGING
    }

    public delegate void MovementDelegate(Vector2 movementVelocity);
}