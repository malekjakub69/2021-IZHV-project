using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Units
{
    [System.Serializable]
    public class Unit : MonoBehaviour
    {
        [Header("Basic Information")]
        
        public string Name;
        public string Description;
        public Sprite Image;
        public int Price;

        [Header("Stats")] 
        
        public float MovementSpeed;
        public float AttackDamage;
        public float AttackSpeed;
        public float AttackRange;
        public float Health;

        [Header("Rewards")]
        public float RewardExp;
        public float RewardMoney;

    }
}
