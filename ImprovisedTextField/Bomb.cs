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
    public class Bomb
    {
        private Rectangle rectBomb;
        private Texture2D TexBomb;
        private Color ColorBomb;

        public int Time;
        public Bomb(Rectangle rectBomb, Texture2D TexBomb, Color ColorBomb)
        {
            this.rectBomb = rectBomb;
            this.TexBomb = TexBomb;
            this.ColorBomb = ColorBomb;
        }

        public Texture2D BombTex
        {
            get { return TexBomb; }
        }
        public Rectangle BombRect
        {
            get { return rectBomb; }
        }

        public Color BombColor
        {
            get { return ColorBomb; }
        }

        public Point Position
        {
            get { return BombRect.Location; }
            set { rectBomb.Location = value; }
        }

        public void timer()
        {
            Time++;
        }
    }
}
