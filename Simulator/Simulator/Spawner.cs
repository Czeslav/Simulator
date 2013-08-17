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
        private Texture2D crateTransparent;
        private Texture2D circle;
        private Shapes whatToDraw;
        private bool waiting = false;

        private Vector2 size1,size2;
        private float width, height;

        public Spawner(World world,ContentManager content)
        {
            this.world = world;
            crate = content.Load<Texture2D>("crate");
            circle = content.Load<Texture2D>("circle");
            crateTransparent = content.Load<Texture2D>("crateTransparent");
            list = new List<DrawablePhysicsObject>();
        }


        public void Update(Sidebar sidebar)
        {
            currentMouse = Mouse.GetState();

            #region button clicking
            if (sidebar.buttons[0].IsClicked())
            {
                whatToDraw = Shapes.Circle;
            }
            if (sidebar.buttons[1].IsClicked())
            {
                whatToDraw = Shapes.Rectangle;
            }
            if (sidebar.buttons[2].IsClicked())
            {
                list.Clear();
                list.TrimExcess();
            }
            #endregion

            #region adding objects

            #region first click
            if (!waiting
                && currentMouse.LeftButton == ButtonState.Pressed
                && prevMouse.LeftButton == ButtonState.Released
                && !sidebar.IsClicked())
            {
                waiting = true;
                size1 = new Vector2(currentMouse.X, currentMouse.Y);
            }
            #endregion

            #region second click
            else if (waiting
                && currentMouse.LeftButton == ButtonState.Pressed 
                && prevMouse.LeftButton == ButtonState.Released
                && !sidebar.IsClicked())
            {
                waiting = false;

                size2 = new Vector2(currentMouse.X, currentMouse.Y);

                DrawablePhysicsObject _object = new DrawablePhysicsObject();
                float positionX, positionY;

                #region getting size of object
                if (size1.X == size2.X || size2.Y == size1.Y)
                {
                    return;
                }

                if (size1.X > size2.X)
                {
                    width = size1.X - size2.X;
                    positionX = size2.X + width / 2.0f;
                }
                else
                {
                    width = size2.X - size1.X;
                    positionX = size1.X + width / 2.0f; 
                }

                if (size1.Y > size2.Y)
                {
                    height = size1.Y - size2.Y;
                    positionY = size2.Y + height / 2.0f;
                }
                else
                {
                    height = size2.Y - size1.Y;
                    positionY = size1.Y + height / 2.0f;
                }
                #endregion

                if (whatToDraw == Shapes.Rectangle)
                {
                    _object = new DrawablePhysicsObject(world, crate, new Vector2(width, height), 1);
                }

                if (whatToDraw == Shapes.Circle)
                {
                    _object = new DrawablePhysicsObject(world, circle, new Vector2(50), 0.25f, 1);
                }
                

                _object.Position = new Vector2(positionX,positionY);

                list.Add(_object);
            }
            #endregion

            #endregion

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
