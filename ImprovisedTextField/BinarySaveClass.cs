using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImprovisedTextField
{
    [Serializable]
    class BinarySaveClass
    {
        public int blockRectPosX;
        public int blockRectPosY;
        public int blockRectWidth;
        public int blockRectHeight;

        public bool blockHasInteracted;

        public int EnemyRectPosX;
        public int EnemyRectPosY;
        public int EnemyRectWidth;
        public int EnemyRectHeight;
        public int EnemyDirection;
        public float EnemyTimer;

        public int PlayerPositionX;
        public int PlayerPositionY;
        public int PlayerLife;

        public int Score;
        public string name;

    }
}
