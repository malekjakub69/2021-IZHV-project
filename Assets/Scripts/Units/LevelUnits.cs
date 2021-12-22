using System.Collections.Generic;
using UnityEngine;

namespace Game.Units
{
    //Třída držící jednotky, které mohou být v daném levelu base
    [System.Serializable]
    public class LevelUnits
    {
        public int BaseLevel;
        
        [SerializeField]
        public List<GameObject> AvailableUnits;
    }
}