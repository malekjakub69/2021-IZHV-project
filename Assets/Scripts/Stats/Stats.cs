using UnityEngine;
using System.Collections;
namespace Game.Stats
{
        //třída urdžující staty pro hráče
    public class Stats : MonoBehaviour
    {
        public float MoneyPerSeconds;
        public float Money;
        public float Exp;

        private void Awake()
        {
            StartCoroutine(GetMoney());
        }

        //Inkrement penež každou sekundu
        IEnumerator GetMoney()
        {
            yield return new WaitForSeconds(1f);
            Money += MoneyPerSeconds;
            StartCoroutine(GetMoney());
        }
    }
}