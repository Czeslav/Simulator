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

        List<Button> buttons;

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
            this.color = Color.LightSkyBlue;


            buttons = new List<Button>();
        }
        #endregion


        public void LoadContent(ContentManager content)
        {

            #region creating buttons

            Rectangle button1rec = new Rectangle(rectangle.Left + 25,rectangle.Top + 25, 200,50);
            Texture2D button1tex = content.Load<Texture2D>("Sidebar/buttonCircle");
            AddButton(button1rec, button1tex);

            Rectangle button2rec = new Rectangle(rectangle.Left + 25, rectangle.Top + 100, 200, 50);
            Texture2D button2tex = content.Load<Texture2D>("sidebar/buttonRectangle");
            AddButton(button2rec, button2tex);


            #endregion

            texture = content.Load<Texture2D>("Sidebar/side");
            border = content.Load<Texture2D>("Sidebar/border");           
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
