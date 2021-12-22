using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    //třída mainmenu
    public class MainMenu: MonoBehaviour
    {

        [SerializeField] public GameObject mapPanel;

        public void Start()
        {
            mapPanel.SetActive(false);
        }

        public void ExitGame()
        {
            Debug.Log("Quit before"); 
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
            Debug.Log("Quit after"); 
        }

        public void Play()
        {
            mapPanel.SetActive(true);
        }

        public void StartDesertMap()
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1f;
        }

        public void StartLabyrinthMap()
        {
            SceneManager.LoadScene(2);
            Time.timeScale = 1f;
        }

        public void BackToMenu()
        {
            mapPanel.SetActive(false);
        }
    }
}