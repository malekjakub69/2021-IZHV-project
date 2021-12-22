using System;
using Game.Units;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Base
{
    [RequireComponent(typeof(Stats.Stats))]
    public class EnemyBase: Base
    {
        [SerializeField]
        private int NextSpawnIndex = -1;


        private void Awake()
        {
            OpponentBasePosition = FindObjectOfType<PlayerBase>().gameObject;
            playerStats = GetComponent<Stats.Stats>();
            units = LevelUnits.Find(unit => unit.BaseLevel == BaseLevel).AvailableUnits;
        }

        private void FixedUpdate()
        {
            var levelUnits = LevelUnits.Find(a => a.BaseLevel == BaseLevel);
            if (NextSpawnIndex == -1)
            {
                NextSpawnIndex = Random.Range(0,levelUnits.AvailableUnits.Count);
            }
            else
            {
                Unit unit = levelUnits.AvailableUnits[NextSpawnIndex].GetComponent<Unit>();
                if (unit.Price < playerStats.Money)
                {
                    GenerateUnit(NextSpawnIndex);
                    NextSpawnIndex = -1;
                }
            }
        }
    }
}