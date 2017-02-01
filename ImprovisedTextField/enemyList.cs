using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace ImprovisedTextField
{
    class enemyList
    {
        private Rectangle previousBlock;
        private Collision collider;

        private Rectangle rectenemy;
        private Texture2D Texenemy;
        private Color Colorenemy;

        private Random randomDecision;

        private bool movingLeft;
        private bool movingRight;
        private bool movingUp;
        private bool movingDown;

        private bool hitLeft;
        private bool hitRight;
        private bool hitUp;
        private bool hitDown;

        private int Decision;

        private float timer;

        public List<Point> position;
        public int numberOfEnemies;

        public enemyList(Rectangle rectenemy, Texture2D Texenemy, Color Colorenemy)
        {
            this.rectenemy = rectenemy;
            this.Texenemy = Texenemy;
            this.Colorenemy = Colorenemy;
                
            //movingRight = true;
            timer = 0f;

            collider = new Collision();

            randomDecision = new Random();

            Decision = randomDecision.Next(0,4);
        }

        public Texture2D enemyTex
        {
            get { return Texenemy; }
        }
        public Rectangle enemyRect
        {
            get { return rectenemy; }
        }

        public Color enemyColor
        {
            get { return Colorenemy; }
        }

        public Point Position
        {
            get { return enemyRect.Location; }
            set { rectenemy.Location = value; }
        }

        public bool Left
        {
            get { return hitLeft; }
            set { hitLeft = value; }
        }

        public bool Right
        {
            get { return hitRight; }
            set { hitRight = value; }
        }

        public bool Up
        {
            get { return hitUp; }
            set { hitUp = value; }
        }

        public bool Down
        {
            get { return hitDown; }
            set { hitDown = value; }
        }

        public float Timer
        {
            get { return timer; }
            set { timer = value; }
        }

        public int decision
        {
            get { return Decision; }
            set { Decision = value; }
        }
        public void move()
        {
            RandomizeDirection();

            if (movingUp)
            {
                Position = new Point(Position.X,Position.Y-1);
            }

            if (movingDown)
            {
                Position = new Point(Position.X,Position.Y+1);
            }

            if (movingLeft)
            {
                Position = new Point(Position.X-1,Position.Y);
            }

            if (movingRight)
            {
                Position = new Point(Position.X+1,Position.Y);
            }

            if (hitUp)
            {
                movingDown = true;
                movingUp = false;
                movingLeft = false;
                movingRight = false;
            }

            if (hitDown)
            {
                movingDown = false;
                movingUp = true;
                movingLeft = false;
                movingRight = false;
            }

            if (hitLeft)
            {
                movingDown = false;
                movingUp = false;
                movingLeft = false;
                movingRight = true;
            }

            if (hitRight)
            {
                movingDown = false;
                movingUp = false;
                movingLeft = true;
                movingRight = false;
            }
        }

        public void Collisions(Blocks s)
        {
            
            if (s.BlockRect.Intersects(enemyRect))
            {
                previousBlock = s.BlockRect;
                if (collider.TouchTopOf(enemyRect, s.BlockRect))
                {
                    Down = true;
                    Up = false;
                }
                else
                    if (collider.TouchBottomOf(enemyRect, s.BlockRect))
                {
                    Up = true;
                    Down = false;
                }

                if (collider.TouchLeftOf(enemyRect, s.BlockRect))
                {
                    Right = true;
                    Left = false;
                }
                else
                    if (collider.TouchRightOf(enemyRect, s.BlockRect))
                {
                    Right = false;
                    Left = true;
                }

            }
            else
            if (previousBlock != null)
            {
                if (!previousBlock.Intersects(rectenemy))
                {
                    Right = false;
                    Up = false;
                    Down = false;
                    Left = false;
                }
            }
        }

        public void bombCollide(Bomb s)
        {
            if (s.BombRect.Intersects(enemyRect))
            {
                previousBlock = s.BombRect;
                if (collider.TouchTopOf(enemyRect, s.BombRect))
                {
                    Down = true;
                    Up = false;
                }
                else
                    if (collider.TouchBottomOf(enemyRect, s.BombRect))
                {
                    Up = true;
                    Down = false;
                }

                if (collider.TouchLeftOf(enemyRect, s.BombRect))
                {
                    Right = true;
                    Left = false;
                }
                else
                    if (collider.TouchRightOf(enemyRect, s.BombRect))
                {
                    Right = false;
                    Left = true;
                }

            }
            else
            if (previousBlock != null)
            {
                if (!previousBlock.Intersects(rectenemy))
                {
                    Right = false;
                    Up = false;
                    Down = false;
                    Left = false;
                }
            }

        }
        public void RandomizeDirection()
        {
            randomDecision = new Random();
            

            timer -= 1 / 60f;


            if (timer <= 0)
            {
                if (Decision == 5)
                {
                    Decision = 1;
                }
                Decision++;


                Up = Decision == 1 ? true : false;
                Down = Decision == 2 ? true : false;
                Left = Decision == 3 ? true : false;
                Right = Decision == 4 ? true : false;

                timer = randomDecision.Next(0, 2);
            }
        }
    }
}
