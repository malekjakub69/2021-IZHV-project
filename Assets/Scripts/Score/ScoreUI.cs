using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Score
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private GameObject highScoreUIElementPrefab;
        [SerializeField] private Transform elementWrapper;

        private List<GameObject> uiElements = new List<GameObject>();

        private void OnEnable()
        {
            HighScoreHandler.onHighScoreListChanged += UpdateUI;
        }

        private void OnDisable()
        {
            HighScoreHandler.onHighScoreListChanged -= UpdateUI;
        }

        public void Start()
        {
            panel.SetActive(false);
        }

        public void ShowPanel()
        {
            panel.SetActive(true);
        }

        public void ClosePanel()
        {
            panel.SetActive(false);
        }

        private void UpdateUI(List<HighScoreElement> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                HighScoreElement el = list[i];

                if (el.Points > 0)
                {
                    if (i >= uiElements.Count)
                    {
                        var inst = Instantiate(highScoreUIElementPrefab, Vector3.zero, Quaternion.identity, elementWrapper);                       
                        uiElements.Add(inst);
                    }

                    //zapíše nebo přepíše name&points
                    var text = uiElements[i].GetComponentsInChildren<TMP_Text>();
                    text[0].text = el.Name;
                    text[1].text = el.Points.ToString();
                }
            }
        }
    }

}
