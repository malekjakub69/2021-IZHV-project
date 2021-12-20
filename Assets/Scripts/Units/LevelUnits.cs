using System.Collections.Generic;

namespace Game.Units
{
    [System.Serializable]
    public class LevelUnits
    {
        public int Level;
        
        public List<Unit> AvailableUnits;
    }
}