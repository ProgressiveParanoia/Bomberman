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
    class Explosion
    {
        private Collision col;
        private Rectangle rectExplosion;
        private Blocks RightCollidedBox;
        private Blocks LeftCollidedBox;
        private Texture2D TexExplosion;
        private Color ColorExplosion;

        public int spriteSheetX;
        public int spriteSheetY;

        public bool killmePls;

        private int spriteDelay;

        private bool deletedLeft;
        private bool deletedRight;
        private bool deletedUp;
        private bool deletedDown;

        private bool hasDestroyedSomething;
        private bool center;
        public bool firstRight;
        public bool secondRight;
        public bool firstLeft;
        public bool secondLeft;
        public bool firstUp;
        public bool firstDown;
        public bool secondUp;
        public bool secondDown;

        List<Rectangle> stuffToDestroy;

        public Explosion(Rectangle rectExplosion, Texture2D TexExplosion, Color ColorExplosion)
        {
            stuffToDestroy = new List<Rectangle>();

            this.rectExplosion = rectExplosion;
            this.TexExplosion = TexExplosion;
            this.ColorExplosion = ColorExplosion;
            col = new Collision();
        }

        public void Animation()
        {
            spriteDelay++;
        }

        public bool isCenter
        {
            get { return center; }
            set { center = value; }
        }
        public bool cleanUp()
        {
            if (!hasKilled)
            {
                if (spriteDelay > 45)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }else
            {
                if (spriteDelay > 15)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public Texture2D ExplosionTex
        {
            get { return TexExplosion; }
        }
        public Rectangle ExplosionRect
        {
            get { return rectExplosion; }
        }

        public Color ExplosionColor
        {
            get { return ColorExplosion; }
        }

        public Point Position
        {
            get { return ExplosionRect.Location; }
            set { rectExplosion.Location = value; }
        }

        public bool hasKilled
        {
            get { return hasDestroyedSomething; }
            set { hasDestroyedSomething = value; }
        }

        public bool removedLeft
        {
            get { return deletedLeft; }
            set { deletedLeft = value; }
        }

        public bool removedRight
        {
            get { return deletedRight; }
            set { deletedRight = value; }
        }
        public void collide(Blocks s)
        {
          if (s.BlockRect.X < Position.X)
          {
              deletedLeft = true;
                LeftCollidedBox = s;
          }else
          if (s.BlockRect.X > Position.X)
          {
              deletedRight = true;
                RightCollidedBox = s;   
          }

           
        }

        public Blocks RightcollidingBlock()
        {
            return RightCollidedBox;
        }

        public Blocks LeftcollidingBlock()
        {
            return LeftCollidedBox;
        }
    }
}
