using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Score
{
    public class HighScoreHandler: MonoBehaviour
    {
        private List<HighScoreElement> HighScoreList = new List<HighScoreElement>();
        [SerializeField] private int maxCount = 8;
        [SerializeField] private string fileName;

        public delegate void OnHighScoreListChanged(List<HighScoreElement> list);

        public static event OnHighScoreListChanged onHighScoreListChanged;

        private void Start()
        {
            LoadHighStart();
            if (onHighScoreListChanged != null)
            {
                onHighScoreListChanged.Invoke(HighScoreList);
            }
        }

        private void LoadHighStart()
        {
            HighScoreList = FileHandler.ReadListFromJSON<HighScoreElement>(fileName);

            // vymazání nadbytečných položek
            while (HighScoreList.Count > maxCount)
            {
                HighScoreList.RemoveAt(maxCount);
            }

            if (onHighScoreListChanged != null)
            {
                onHighScoreListChanged.Invoke(HighScoreList);
            }

        }

        private void SaveHighScore()
        {
            FileHandler.SaveToJSON<HighScoreElement>(HighScoreList, fileName);
        }

        public void AddHighScoreIfPossible(HighScoreElement element)
        {
            //Cyklus pro prvky, které lze zobrazit
            for (int i = 0; i < maxCount; i++)
            {
                // Pokud je i na konci listu nebo je aktuální skore vyšší než přečtené, zapíše se nová položka
                if (i >= HighScoreList.Count || element.Points > HighScoreList[i].Points)
                {
                    //Zápis
                    HighScoreList.Insert(i, element);
                    // vymazání nadbytečných položek
                    while (HighScoreList.Count > maxCount)
                    {
                        HighScoreList.RemoveAt(maxCount);
                    }
                    //Uložení do JSONu
                    SaveHighScore();
                    
                    //Invokace změny
                    if (onHighScoreListChanged != null)
                    {
                        onHighScoreListChanged.Invoke(HighScoreList);
                    }
                    
                    break;
                }
            }
        }
    }
}