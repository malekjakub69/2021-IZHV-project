using System.Collections.Generic;
using UnityEngine;

namespace Game.Units
{
    [System.Serializable]
    public class LevelUnits
    {
        public int Level;
        
        [SerializeField]
        public List<Unit> AvailableUnits;
    }
}