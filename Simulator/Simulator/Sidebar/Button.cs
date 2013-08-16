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
    class Button
    {
        private Rectangle rectangle;
        private MouseState mouse;
        private Texture2D texture;

        public Button(Rectangle rectangle, Texture2D texture)
        {
            this.rectangle = rectangle;
            this.texture = texture;
        }


        public bool IsClicked()
        {
            mouse = Mouse.GetState();

            if (mouse.X > rectangle.Left && mouse.X<rectangle.Right
                && mouse.Y > rectangle.Top && mouse.Y <rectangle.Bottom
                && mouse.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.LightSkyBlue);
        }


    }
}
