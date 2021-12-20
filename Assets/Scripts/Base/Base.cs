using System.Collections.Generic;
using Game.Units;
using UnityEngine;

namespace Game.Base
{
    [System.Serializable]
    public abstract class Base :MonoBehaviour
    {
        [Header("Basic information")] 
        public float Health;
        public Transform SpawnPoint;
        public int Level;

        [SerializeField]
        public List<LevelUnits> LevelUnits;
    }
}