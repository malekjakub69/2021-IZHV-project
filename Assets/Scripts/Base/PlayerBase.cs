using UnityEngine;
using Game.Stats;
using Game.Units;
using Game.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.AI;

namespace Game.Base
{
    public class PlayerBase: Base
    {
        private void Awake()
        {
            EnemyBasePosition = FindObjectOfType<EnemyBase>().transform;
            playerStats = GetComponent<Stats.Stats>();
            units = LevelUnits.Find(unit => unit.BaseLevel == BaseLevel).AvailableUnits;
            playerUI = FindObjectOfType<PlayerUI>();
        }
    }
}