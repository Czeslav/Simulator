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
    class Sidebar
    {
        Texture2D texture;
        Texture2D border;
        Rectangle rectangle;

        public List<Button> buttons;

        #region private functions
        private void AddButton(Rectangle buttonRectangle, Texture2D buttonTexture)
        {
            Button button = new Button(buttonRectangle, buttonTexture);


            buttons.Add(button);
        }
        #endregion

        #region constructor
        public Sidebar(Rectangle rectangle)
        {
            this.rectangle = rectangle;

            buttons = new List<Button>();
        }
        #endregion

        public bool IsClicked()
        {
            MouseState mouse = Mouse.GetState();
            if (mouse.LeftButton == ButtonState.Pressed
                && mouse.X > rectangle.Left)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void LoadContent()
        {

            #region creating buttons

            Rectangle button1rec = new Rectangle(rectangle.Left + 25,rectangle.Top + 25, 50,50);
            Texture2D button1tex = SpriteBank.buttonCircle;
            AddButton(button1rec, button1tex);

            Rectangle button2rec = new Rectangle(rectangle.Right - 65, rectangle.Top + 25, 50, 50);
            Texture2D button2tex = SpriteBank.buttonRectangle;
            AddButton(button2rec, button2tex);

            Rectangle buttonClearRec = new Rectangle(rectangle.Left + 35, rectangle.Bottom - 100, 100, 50);
            Texture2D buttonCleartex = SpriteBank.buttonClear;
            AddButton(buttonClearRec, buttonCleartex);

            #endregion


            texture = SpriteBank.sidebar;
            border = SpriteBank.border;         
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
            Rectangle borderRectangle = new Rectangle(rectangle.Left, rectangle.Top, border.Width, rectangle.Height);
            spriteBatch.Draw(border, borderRectangle, Color.White);

            foreach (var button in buttons)
            {
                button.Draw(spriteBatch);
            }
        }


    }
}
