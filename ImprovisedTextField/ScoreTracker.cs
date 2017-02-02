﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImprovisedTextField
{
    class ScoreTracker
    {
        private int Score;
        private String Name;

        public int savedScore;
        public String savedName;

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
