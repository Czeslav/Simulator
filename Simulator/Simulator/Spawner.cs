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
    class Spawner
    {
        private World world;
        private MouseState currentMouse;
        private MouseState prevMouse;
        private List<DrawablePhysicsObject> list;
        private Texture2D texture;

        const int width = 50;
        const int height = 50;

        public Spawner(World world,Texture2D texture)
        {
            this.world = world;
            this.texture = texture;
            list = new List<DrawablePhysicsObject>();
        }



        public void Update()
        {
            currentMouse = Mouse.GetState();

            if (currentMouse.LeftButton == ButtonState.Pressed && prevMouse.LeftButton == ButtonState.Released)
            {

                DrawablePhysicsObject _object = new DrawablePhysicsObject(world, texture, new Vector2(width, height), 1);

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
