using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Units
{
    [CreateAssetMenu(fileName = "New Unit", menuName = "New Unit/Basic")]
    public class BasicUnit : ScriptableObject
    {

        public enum unitType
        {
            Warrior,
            Farmer,
            Dealer,
        }

        
        [Header("Unit Settings")]
        [Space(15)]
        
        public unitType Type;
        
        public string unitName;

        
        public GameObject playerPrefab;
        public GameObject enemyPrefab;

        [Header("Unit Stats")]
        [Space(15)]
        
        public int cost;
        public int attack;
        public int health;
        public int capacity;

    }
}