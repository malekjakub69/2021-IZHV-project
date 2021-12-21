using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private TMPro.TMP_Text MoneyText;
        [SerializeField] private List<Button> unitButtons;
        
        private Stats.Stats playerStats;

        public void UpdateMoney()
        {
            MoneyText.text = playerStats.Money.ToString();
        }
        
    }
}
