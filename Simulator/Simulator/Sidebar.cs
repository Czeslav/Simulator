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

using FarseerPhysics.Collision;
using FarseerPhysics.Common;
using FarseerPhysics.Controllers;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;


namespace Simulator
{
    class Sidebar
    {
        Texture2D texture;
        Texture2D border;
        Rectangle rectangle;
        Color color;

        public Sidebar(Texture2D texture, Texture2D border, Rectangle rectangle,Color color)
        {
            this.texture = texture;
            this.border = border;
            this.rectangle = rectangle;
            this.color = color;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, color);
            Rectangle borderRectangle = new Rectangle(rectangle.Left, rectangle.Top, border.Width, rectangle.Height);
            spriteBatch.Draw(border, borderRectangle, Color.White);
        }


    }
}
