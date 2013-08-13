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
        Color color;
        SpriteFont buttonFont;

        List<Button> buttons;

        #region private functions
        private void AddButton(Rectangle buttonRectangle, string buttonText, SpriteFont font )
        {
            Button button = new Button(buttonRectangle, buttonText, font);


            buttons.Add(button);
        }
        #endregion

        #region constructor
        public Sidebar(Rectangle rectangle,Color color,SpriteFont font)
        {
            this.rectangle = rectangle;
            this.color = color;


            buttons = new List<Button>();
        }
        #endregion


        public void LoadContent(ContentManager content)
        {

            #region creating buttons
            buttonFont = content.Load<SpriteFont>("ButtonFont");

            Rectangle button1rec = new Rectangle(rectangle.Left + 25,rectangle.Top + 25, 150,100);
            AddButton(button1rec, "Ave", buttonFont);


            #endregion

            texture = content.Load<Texture2D>("side");
            border = content.Load<Texture2D>("border");
            foreach (var button in buttons)
            {
                button.LoadContent(content);
            }
            
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, color);
            Rectangle borderRectangle = new Rectangle(rectangle.Left, rectangle.Top, border.Width, rectangle.Height);
            spriteBatch.Draw(border, borderRectangle, Color.White);

            foreach (var button in buttons)
            {
                button.Draw(spriteBatch);
            }
        }


    }
}
