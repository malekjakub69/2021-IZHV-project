using UnityEngine;
using Game.Stats;
namespace Game.Base
{
    public class PlayerBase: Base
    {
        [HideInInspector]
        public Transform EnemyBasePosition;
        private Stats.Stats playerStats;
        private void Awake()
        {
            EnemyBasePosition = FindObjectOfType<EnemyBase>().transform;
        }

        public void LevelUp()
        {

        }

        public void GenerateUnit(GameObject prefab)
        {

        }
    }
}