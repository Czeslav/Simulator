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
    public class DrawablePhysicsObject
    {
        // Because Farseer uses 1 unit = 1 meter we need to convert
        // between pixel coordinates and physics coordinates.
        // I've chosen to use the rule that 100 pixels is one meter.
        // We have to take care to convert between these two
        // coordinate-sets wherever we mix them!

        public const float unitToPixel = 100.0f;
        public const float pixelToUnit = 1 / unitToPixel;

        public Body body;
        public Vector2 Position
        {
            get { return body.Position * unitToPixel; }
            set { body.Position = value * pixelToUnit; }
        }

        public Texture2D texture;

        bool freezed = false;

        private Vector2 size;
        public Vector2 Size
        {
            get { return size * unitToPixel; }
            set { size = value * pixelToUnit; }
        }

        #region constructors

        //blank constructor
        public DrawablePhysicsObject()
        {
        }

        //constructor for rectangle
        public DrawablePhysicsObject(World world, Texture2D texture, Vector2 size, float mass)
        {

            body = BodyFactory.CreateRectangle(world, size.X * pixelToUnit, size.Y * pixelToUnit, 1);
            body.BodyType = BodyType.Dynamic;

            this.Size = size;
            this.texture = texture;
        }

        //constructor for circle
        public DrawablePhysicsObject(World world, Texture2D texture, Vector2 size, float radius, float density)
        {

            body = BodyFactory.CreateCircle(world, radius, density);
            body.BodyType = BodyType.Dynamic;

            this.Size = size;
            this.texture = texture;
        }
        

        #endregion

        MouseState currentMouse, prevMouse;

        public bool IsRightClicked()
        {
            currentMouse = Mouse.GetState();
            Vector2 pos = Position;

            if (currentMouse.RightButton == ButtonState.Pressed
                && prevMouse.RightButton == ButtonState.Released
                && currentMouse.X > Position.X - Size.X / 2
                && currentMouse.X < Position.X + Size.X / 2
                && currentMouse.Y > Position.Y - Size.Y / 2
                && currentMouse.Y < Position.Y + Size.Y / 2)
            {
                prevMouse = currentMouse;
                return true;
            }
            else
            {
                prevMouse = currentMouse;
                return false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (body.BodyType == BodyType.Static)
            {
                freezed = true;
            }
            else
            {
                freezed = false;
            }

            Vector2 scale = new Vector2(Size.X / (float)texture.Width, Size.Y / (float)texture.Height);
            if (freezed)
            {
                spriteBatch.Draw(texture, Position, null, Color.Gray, body.Rotation, new Vector2(texture.Width / 2.0f, texture.Height / 2.0f), scale, SpriteEffects.None, 0);
            }
            else
            {
                spriteBatch.Draw(texture, Position, null, Color.White, body.Rotation, new Vector2(texture.Width / 2.0f, texture.Height / 2.0f), scale, SpriteEffects.None, 0);
            }
        }
    }
}
