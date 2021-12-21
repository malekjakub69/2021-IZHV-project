using UnityEngine;
using Game.Stats;
using Game.Units;
using Game.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.AI;

namespace Game.Base
{
    [RequireComponent(typeof(Stats.Stats))]
    public class PlayerBase: Base
    {
        Transform SpawningPosition;

        public float LevelUpCost = 5000;
        private Transform EnemyBasePosition;
        private Stats.Stats playerStats;
        private PlayerUI playerUI;
        List<GameObject> units;

        Queue<GameObject> buildingUnitQueue = new Queue<GameObject>();

        private void Awake()
        {
            EnemyBasePosition = FindObjectOfType<EnemyBase>().transform;
            playerUI = FindObjectOfType<PlayerUI>();
            playerStats = GetComponent<Stats.Stats>();
            units = LevelUnits.Find(unit => unit.Level == Level).AvailableUnits;
        }

        public void LevelUp()
        {
            if (playerStats.Exp > LevelUpCost) {
                LevelUpCost = float.MaxValue;
                Level++;
                units = LevelUnits.Find(unit => unit.Level == Level).AvailableUnits;
            }
        }

        public void GenerateUnit(GameObject prefab)
        {
            Unit unit = prefab.GetComponent<Unit>();
            if (unit == null) return;
            if (playerStats.Money >= unit.Price)
            {
                playerStats.Money -= unit.Price;
                buildingUnitQueue.Enqueue(prefab);
                if (buildingUnitQueue.Count == 1)
                {
                    StartCoroutine(WaitBuildingTimeAndGenerateUnit());
                }
            }
        }
        

        public void GenerateUnit(int indexOfUnit)
        {         
            if (indexOfUnit >= units.Count) return;
            GameObject unitToGenerate = units[indexOfUnit];
            GenerateUnit(unitToGenerate);
        }

        IEnumerator WaitBuildingTimeAndGenerateUnit()
        {
            GameObject unitToSpawn = buildingUnitQueue.Peek();
            Unit unit = unitToSpawn.GetComponent<Unit>();
            unit.enemyBase = EnemyBasePosition;

            yield return new WaitForSeconds(unit.BuildingTime);

            buildingUnitQueue.Dequeue();
            int indexOfSpawnPoint = Random.Range(0, SpawnPoints.Count);
            Transform position = SpawnPoints[indexOfSpawnPoint];
            Quaternion rotation = unitToSpawn.transform.rotation;
            var gameObject = Instantiate(unitToSpawn, position.position, rotation);
            if (buildingUnitQueue.Count >= 1) {
                StartCoroutine(WaitBuildingTimeAndGenerateUnit());
            }
            gameObject.GetComponent<Unit>().enemyBase = EnemyBasePosition;
        }
    }
}