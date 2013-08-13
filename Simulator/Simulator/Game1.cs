using System;
using System.Collections.Generic;
using System.Linq;
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

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont buttonFont;

        World world;

        DrawablePhysicsObject floor;
       // Sidebar sidebar;


        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

       

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            buttonFont = Content.Load<SpriteFont>("ButtonFont");

            world = new World(new Vector2(0, 10));

            #region floor
            floor = new DrawablePhysicsObject(world, Content.Load<Texture2D>("floor"), new Vector2(GraphicsDevice.Viewport.Width,50), 10);
            floor.body.BodyType = BodyType.Static;
            floor.Position = new Vector2(GraphicsDevice.Viewport.Width /2, GraphicsDevice.Viewport.Height - 25);
            #endregion
            #region sidebar
            //Rectangle rectangle = new Rectangle((int)(GraphicsDevice.Viewport.Width * 0.7f),0,(int)(GraphicsDevice.Viewport.Width*0.3f),GraphicsDevice.Viewport.Height);
            //sidebar = new Sidebar(rectangle, Color.Gray, buttonFont);
            #endregion

            //sidebar.LoadContent(Content);
        }

        


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        



        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            spriteBatch.Begin();

                floor.Draw(spriteBatch);
                //sidebar.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
