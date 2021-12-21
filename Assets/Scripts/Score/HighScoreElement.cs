using System;

namespace Game.Score
{

    [Serializable]
    public class HighScoreElement
    {
        public string Name;
        public int Points;

        public HighScoreElement(string name, int points)
        {
            Name = name;
            Points = points;
        }

    }
}