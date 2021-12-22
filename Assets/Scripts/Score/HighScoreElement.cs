using System;

namespace Game.Score
{

    //Třída držící skore hráče a jeho jméno
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