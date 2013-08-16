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
    enum Shapes { Rectangle, Circle };

    class Spawner
    {
        private World world;
        private MouseState currentMouse;
        private MouseState prevMouse;
        private List<DrawablePhysicsObject> list;
        private Texture2D crate;
        private Texture2D circle;
        private Shapes whatToDraw;

        const int width = 50;
        const int height = 50;

        public Spawner(World world,ContentManager content)
        {
            this.world = world;
            crate = content.Load<Texture2D>("crate");
            circle = content.Load<Texture2D>("circle");
            list = new List<DrawablePhysicsObject>();
        }


        public void Update(Sidebar sidebar)
        {
            currentMouse = Mouse.GetState();

            if (sidebar.buttons[0].IsClicked())
            {
                whatToDraw = Shapes.Circle;
            }
            if (sidebar.buttons[1].IsClicked())
            {
                whatToDraw = Shapes.Rectangle;
            }

            if (currentMouse.LeftButton == ButtonState.Pressed && prevMouse.LeftButton == ButtonState.Released)
            {
                DrawablePhysicsObject _object = new DrawablePhysicsObject();

                if (whatToDraw == Shapes.Rectangle)
                {
                    _object = new DrawablePhysicsObject(world, crate, new Vector2(width, height), 1);
                }

                if (whatToDraw == Shapes.Circle)
                {
                    _object = new DrawablePhysicsObject(world, circle, new Vector2(width, height), 0.25f, 1);
                }
                

                _object.Position = new Vector2(currentMouse.X, currentMouse.Y);

                list.Add(_object);
            }

            prevMouse = currentMouse;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in list)
            {
                item.Draw(spriteBatch);
            }
        }


    }
}
