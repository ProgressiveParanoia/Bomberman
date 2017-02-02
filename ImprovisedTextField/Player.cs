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
    public class Player
    {
        private Rectangle previousBlock;
        private Collision collider;

        private Rectangle rectPlayer;
        private Texture2D TexPlayer;
        private Color ColorPlayer;

        private bool movingLeft;
        private bool movingRight;
        private bool movingUp;
        private bool movingDown;

        private bool hasFirePowerUp;
        private bool hasMultipleBombPowerUp;

        private bool hitLeft;
        private bool hitRight;
        private bool hitUp;
        private bool hitDown;

        private int spriteSheetX;
        private int spriteSheetY;

        private int bombCount;
        private int Life;
        private int animDelay;

        public Player(Rectangle rectPlayer, Texture2D TexPlayer, Color ColorPlayer)
        {
            this.rectPlayer = rectPlayer;
            this.TexPlayer = TexPlayer;
            this.ColorPlayer = ColorPlayer;

            collider = new Collision();

            lives = 3;
        }

        public Player()
        {
           
        }
        public Texture2D PlayerTex
        {
            get { return TexPlayer; }
        }
        public Rectangle PlayerRect
        {
            get { return rectPlayer; }
        }

        public Color PlayerColor
        {
            get { return ColorPlayer; }
        }

        public Point Position
        {
            get { return PlayerRect.Location; }
            set { rectPlayer.Location = value; }
        }

        public bool hasBombRange
        {
            get { return hasFirePowerUp; }
            set { hasFirePowerUp = value; }
        }

        public bool hasMulti
        {
            get { return hasMultipleBombPowerUp; }
            set { hasMultipleBombPowerUp = value; }
        }

        public bool moveLeft
        {
            get { return movingLeft; }
        }

        public bool moveRight
        {
            get { return movingRight; }
        }

        public bool moveUp
        {
            get { return movingUp; }
        }

        public bool moveDown
        {
            get { return movingDown; }
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
        public int SpriteSheetX
        {
            get { return spriteSheetX; }
        }
        public int SpriteSheetY
        {
            get { return spriteSheetY; }
        }
       public int lives
        {
            get { return Life; }
            set { Life = value; }
        }
        public int BombCTR
        {
            get { return bombCount; }
            set { bombCount = value; }
        }

        public void playerAnimation()
        {
            if (movingUp)
            {
                if (animDelay > 10)
                {
                    spriteSheetY = 0;

                    if (spriteSheetX < 42)
                    {
                        spriteSheetX += 21;
                    }
                    else
                    {
                        spriteSheetX = 0;
                    }
                    animDelay = 0;
                }
            }

            if (movingDown)
            {
                if (animDelay > 10)
                {
                    spriteSheetY = 50;

                    if (spriteSheetX < 42)
                    {
                        spriteSheetX += 21;
                    }
                    else
                    {
                        spriteSheetX = 0;
                    }
                    animDelay = 0;
                }
            }

            if (movingLeft)
            {
                if (animDelay > 10)
                {
                    spriteSheetY = 25;

                    if (spriteSheetX < 42)
                    {
                        spriteSheetX += 21;
                    }
                    else
                    {
                        spriteSheetX = 0;
                    }
                    animDelay = 0;
                }
            }

            if (movingRight)
            {
                if (animDelay > 10)
                {
                    spriteSheetY = 75;

                    if (spriteSheetX < 42)
                    {
                        spriteSheetX += 21;
                    }
                    else
                    {
                        spriteSheetX = 0;
                    }
                    animDelay = 0;
                }
            }
            animDelay++;
        }

        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                movingDown = false;
                movingUp = true;
                movingLeft = false;
                movingRight = false;
            }
            else if(Keyboard.GetState().IsKeyUp(Keys.W))
            {
                movingUp = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                movingDown = true;
                movingUp = false;
                movingLeft = false;
                movingRight = false;
            }
            else
            if (Keyboard.GetState().IsKeyUp(Keys.S))
            {
                movingDown = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                movingDown = false;
                movingUp = false;
                movingLeft = true;
                movingRight = false;

            }
            else
               if (Keyboard.GetState().IsKeyUp(Keys.A))
            {
                movingLeft = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                movingDown = false;
                movingUp = false;
                movingLeft = false;
                movingRight = true;
            }
            else
               if (Keyboard.GetState().IsKeyUp(Keys.D))
            {
                movingRight = false;
            }

            if (movingUp && !hitUp)
            {
                Position = new Point(Position.X, Position.Y - 1);
            }

            if (movingDown && !hitDown)
            {
                Position = new Point(Position.X, Position.Y + 1);
            }

            if (movingRight && !hitRight)
            {
                Position = new Point(Position.X + 1, Position.Y);
            }

            if (movingLeft && !hitLeft)
            {
                Position = new Point(Position.X - 1, Position.Y);
            }
        }
        public void Collisions(Rectangle s)
        {

            if (s.Intersects(PlayerRect))
            {

                previousBlock = s;
                //assess X axis
                if(collider.TouchTopOf(PlayerRect, s))
                {
                    Down = true;
                    Up = false;
                }else
                    if (collider.TouchBottomOf(PlayerRect, s))
                {
                    Up = true;
                    Down = false;
                }

                if(collider.TouchLeftOf(PlayerRect, s))
                {
                    Right = true;
                    Left = false;
                }else 
                    if(collider.TouchRightOf(PlayerRect, s))
                {
                    Right = false;
                    Left = true;
                }

                //if (collider.TouchLeftOf(PlayerRect, s))
                //{
                //    Console.WriteLine("EYAAA");
                //}
            }
            else
            if (previousBlock != null)
            {
                if (!previousBlock.Intersects(rectPlayer))
                {
                    Right = false;
                    Up = false;
                    Down = false;
                    Left = false;
                }
            }
        }
    }
}
