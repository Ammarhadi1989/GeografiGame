using System;
using System.Collections.Generic;
using System.Text;

namespace GeografiGame
{
    public class ScoreList : IComparable<ScoreList>
    {
        public string PlayerName { get; set; }

        public int HighScore { get; set; }
        
        public ScoreList(string name, int score)
        {
            PlayerName = name;
            HighScore = score;
        }
        // Gör att vi kan sortera listan automatiskt (högst poäng först)
        public int CompareTo(ScoreList other)
        {
            if (other == null) return 1;
            return other.HighScore.CompareTo(this.HighScore);
        }
    }
}
