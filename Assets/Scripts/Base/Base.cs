using System.Collections;
using System.Collections.Generic;
using Game.Stats;
using Game.UI;
using Game.Units;
using UnityEngine;

namespace Game.Base
{
    public abstract class Base :MonoBehaviour
    {
        [SerializeField] 
        public float Health = 1000f;
        [SerializeField] 
        public List<Transform> SpawnPoints;
        [SerializeField] 
        public int BaseLevel = 1;

        protected Stats.Stats playerStats;
        protected List<GameObject> units;
        
        public float LevelUpCost = 5000;
        protected GameObject OpponentBasePosition;
        protected PlayerUI playerUI;

        Queue<GameObject> buildingUnitQueue = new Queue<GameObject>();

        [SerializeField]
        public List<LevelUnits> LevelUnits;
        
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

        public void LevelUp()
        {
            if (playerStats.Exp > LevelUpCost) {
                LevelUpCost = float.MaxValue;
                BaseLevel++;
                units = LevelUnits.Find(unit => unit.BaseLevel == BaseLevel).AvailableUnits;
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
            unit.enemyBase = OpponentBasePosition;

            yield return new WaitForSeconds(unit.BuildingTime);

            buildingUnitQueue.Dequeue();
            int indexOfSpawnPoint = Random.Range(0, SpawnPoints.Count);
            Transform position = SpawnPoints[indexOfSpawnPoint];
            Quaternion rotation = unitToSpawn.transform.rotation;
            var gameObject = Instantiate(unitToSpawn, position.position, rotation);
            if (buildingUnitQueue.Count >= 1) {
                StartCoroutine(WaitBuildingTimeAndGenerateUnit());
            }
            gameObject.GetComponent<Unit>().enemyBase = OpponentBasePosition;
        }
    }
}