using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    //Třída zapisující hodnoty do UI
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text MoneyText;
        [SerializeField] private TMP_Text ExpText;

        [SerializeField]  private Stats.Stats playerStats;


        private void UpdateMoney()
        {
            MoneyText.text = playerStats.Money.ToString();
        }

        private void UpdateExp()
        {
            ExpText.text = playerStats.Exp.ToString();
        }

        private void FixedUpdate()
        {
            UpdateMoney();
            UpdateExp();
        }

    }
}
