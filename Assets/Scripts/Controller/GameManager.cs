using UnityEngine;

namespace escape4u
{
    public class GameManager : MonoBehaviour
    {
        public PlayerController controller;
        public Character player;

        void Awake()
        {
            controller.PossessCharacter(player);
        }
    }
}
