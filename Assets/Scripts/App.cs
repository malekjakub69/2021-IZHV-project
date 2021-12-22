using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    //Třída behu hry
    public class App : MonoBehaviour
    {
        [SerializeField] private Image currentImage;
        [SerializeField] private Sprite pauseImage;
        [SerializeField] private Sprite resumeImage;
        [SerializeField] private GameObject mainMenuButton;

        private bool isPaused = false;

        public void Start()
        {
            mainMenuButton.SetActive(false);
        }

        public void PauseGame()
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0f;
                currentImage.sprite = resumeImage;
                mainMenuButton.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                currentImage.sprite = pauseImage;
                mainMenuButton.SetActive(false);
            }
        }

        public void ExitGame()
        {
            //save score to JSON
            //reset game score and money
            SceneManager.LoadScene(0);
        }
    }
}
