using System.Collections.Generic;
using Game.Units;
using UnityEngine;

namespace Game.Base
{
    [System.Serializable]
    public abstract class Base
    {
        [Header("Basic information")] 
        public float Health;
        public Transform SpawnPoint;
        public int Level;

        public List<LevelUnits> LevelUnits;
    }
}