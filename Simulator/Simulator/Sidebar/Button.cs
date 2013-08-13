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
        private string text;
        private MouseState mouse;
        private SpriteFont font;
        private Texture2D texture;

        Texture2D center;

        public Button(Rectangle rectangle, string text, SpriteFont font)
        {
            this.rectangle = rectangle;
            this.text = text;
            this.font = font;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("button");
            center = content.Load<Texture2D>("side");
        }

        public bool IsClicked()
        {
            mouse = Mouse.GetState();

            if (mouse.X > rectangle.Left && mouse.X<rectangle.Right
                && mouse.Y > rectangle.Top && mouse.Y <rectangle.Bottom)
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
            spriteBatch.Draw(texture, rectangle, Color.Gray);

            Vector2 textPosition = new Vector2(rectangle.Center.X - text.Length * 10, rectangle.Center.Y - 12);
            spriteBatch.Draw(center, new Rectangle((int)textPosition.X, (int)textPosition.Y, 1, 1), Color.White);
            spriteBatch.DrawString(font,text,textPosition,Color.White);
        }


    }
}
