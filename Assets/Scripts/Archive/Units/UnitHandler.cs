using System.Collections;
using System.Collections.Generic;
using Game.Units.Player;
using UnityEngine;

namespace Game.Units
{
    public class UnitHandler : MonoBehaviour
    {
        public static UnitHandler instance;

        [SerializeField]
        private BasicUnit dealer, farmer, warrior;
        void Start()
        {
            instance = this;
        }

        public (int cost, int attack, int health, int capacity) GetBasicUnitStats(string type)
        {
            BasicUnit unit;
            switch (type)
            {
                case "dealer":
                    unit = dealer;
                    break;
                case "farmer":
                    unit = farmer;
                    break;
                case "warrior":
                    unit = warrior;
                    break;
                default:
                    Debug.Log($"Unit Type : {type} could not be fond.");
                    return (0, 0, 0, 0);
            }
            return (unit.cost, unit.attack, unit.health, unit.capacity);
        }

        public void SetBasicUnitStats(Transform type)
        {
            foreach (Transform child in type)
            {
                foreach (Transform unit in child)
                {
                    string unitName = child.name.Substring(0, child.name.Length-1).ToLower(); //Warriors -> warrior
                    var stats = GetBasicUnitStats(unitName);
                    PlayerUnit pU;

                    if (type == Game.Player.PlayerManager.instance.playerUnits)
                    {
                        pU = unit.GetComponent<PlayerUnit>();
                    
                        pU.cost = stats.cost;
                        pU.attack = stats.attack;
                        pU.capacity = stats.capacity;
                        pU.health = pU.health;
                    }
                    else if (type == Game.Player.PlayerManager.instance.enemyUnits)
                    {
                        //enemy stats??
                    }

                    //add upgrades ?
                }
            }
        }
    }
}