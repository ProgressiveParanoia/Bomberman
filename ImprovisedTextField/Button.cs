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
    class Button
    {
        private Rectangle rectBtn;
        private Texture2D TexBtn;
        private Color ColorBtn;

        public Button(Rectangle rectBtn, Texture2D TexBtn, Color ColorBtn)
        {
            this.rectBtn = rectBtn;
            this.TexBtn = TexBtn;
            this.ColorBtn = ColorBtn;
        }

        public Texture2D btnTex
        {
            get { return TexBtn; }
        }
        public Rectangle btnRect
        {
            get { return rectBtn; }
        }

        public Color btnColor
        {
            get { return ColorBtn; }
        }
    }
}
