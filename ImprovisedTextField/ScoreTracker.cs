using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImprovisedTextField
{
    public class ScoreTracker
    {
        private int Score;
        private String Name;

        public int savedScore;
        public String savedName;

        public string emptySpace;

        public ScoreTracker(int Score, String Name)
        {
            this.Name = Name;
            this.Score = Score;
        }

        public ScoreTracker()
        {
            savedScore = 0;
            savedName = "";
        }

        public int score
        {
            get { return Score; }
            set { Score = value; }
        }

        public String name
        {
            get { return Name; }
            set { Name = value; }
        }

    }
}
