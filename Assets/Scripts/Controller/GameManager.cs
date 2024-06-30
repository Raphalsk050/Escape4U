using UnityEngine;
using UnityEngine.SceneManagement;

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

        public void StartGame(){
            //SceneManager.LoadScene("MainGame");
        }

        public void RestartGame(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void KillPlayer(){
            RestartGame();
        }
    }
}
