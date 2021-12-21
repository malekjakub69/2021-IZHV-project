using System.Collections.Generic;
using Game.Units;
using UnityEngine;

namespace Game.Base
{
    [System.Serializable]
    public abstract class Base :MonoBehaviour
    {
        public float Health = 1000f;
        public List<Transform> SpawnPoints;
        public int Level = 1;

        [SerializeField]
        public List<LevelUnits> LevelUnits;
    }
}