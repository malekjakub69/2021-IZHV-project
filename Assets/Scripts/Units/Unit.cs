using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Units
{
    [System.Serializable]
    public abstract class Unit
    {
        [Header("Basic Information")]
        
        public string Name;
        public string Description;

        public int Price;

        [Header("Stats")] 
        
        public float MovementSpeed;

        public float AttackDamage;
        public float AttackSpeed;
        public float AttackRange;
        
        public float Health;
        
        
        
        public void Attack()
        {
            
        }

    }
}
