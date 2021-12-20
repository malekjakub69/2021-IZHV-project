using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class App : MonoBehaviour
    {
        [SerializeField] private Image currentImage;
        [SerializeField] private Sprite pauseImage;
        [SerializeField] private Sprite resumeImage;

        private bool isPaused = false;

        public void PauseGame()
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0f;
                currentImage.sprite = pauseImage;
            }
            else
            {
                Time.timeScale = 1f;
                currentImage.sprite = resumeImage;
            }
        }
    }
}
