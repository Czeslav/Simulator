using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Simulator
{
    class SpriteBank
    {

        #region textures

        public Texture2D circle, crate, floor;
        public Texture2D border, buttonCircle, buttonClear, buttonRectangle, sidebar;

        #endregion

        public void LoadTextures(ContentManager content)
        {
            circle = content.Load<Texture2D>("circle");
            crate = content.Load<Texture2D>("crate");
            floor = content.Load<Texture2D>("floor");

            border = content.Load<Texture2D>("Sidebar/border");
            buttonCircle = content.Load<Texture2D>("Sidebar/buttonCircle");
            buttonClear = content.Load<Texture2D>("Sidebar/buttonClear");
            buttonRectangle = content.Load<Texture2D>("Sidebar/buttonRectangle");
            sidebar = content.Load<Texture2D>("Sidebar/sidebar");

        }

    }
}
