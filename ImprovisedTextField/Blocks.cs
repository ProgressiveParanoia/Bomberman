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

    public class Blocks
    {
        private Rectangle rectBlock;
        private Texture2D TexBlock;
        private Color ColorBlock;

        public List<Point> position;
        public int numberOfBlocks;

        private bool hasBeenPickedUp;
        
        public Blocks(Rectangle rectBlock, Texture2D TexBlock, Color ColorBlock)
        {
            this.rectBlock = rectBlock;
            this.TexBlock = TexBlock;
            this.ColorBlock = ColorBlock;
        }
        public Blocks()
        {
            position = new List<Point>();
            numberOfBlocks = 0;
        }

        public Texture2D BlockTex
        {
            get { return TexBlock; }
        }
        public Rectangle BlockRect
        {
            get { return rectBlock; }
            set { rectBlock = value; }
        }

        public Color BlockColor
        {
            get { return ColorBlock; }
        }

        public Point Position
        {
            get { return BlockRect.Location; }
            set { rectBlock.Location = value; }
        }

        public bool hasPower
        {
            get { return hasBeenPickedUp; }
            set { hasBeenPickedUp = value; }
        }
    }
}
