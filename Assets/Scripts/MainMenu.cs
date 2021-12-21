using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class MainMenu: MonoBehaviour
    {
        public void ExitGame()
        {
            Debug.Log("Quit before"); 
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
            Debug.Log("Quit after"); 
        }

        public void Play()
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1f;
        }
    }
}