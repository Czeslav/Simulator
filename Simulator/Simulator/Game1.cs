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

        World world;
        Sidebar sidebar;
        Spawner spawner;

        DrawablePhysicsObject floor;

        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }


        protected override void Initialize()
        {

            world = new World(new Vector2(0,10));


            base.Initialize();
        }

        


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            spawner = new Spawner(world,Content);

            #region floor
            floor = new DrawablePhysicsObject(world, Content.Load<Texture2D>("floor"), new Vector2(GraphicsDevice.Viewport.Width,50), 10);
            floor.body.BodyType = BodyType.Static;
            floor.Position = new Vector2(GraphicsDevice.Viewport.Width /2, GraphicsDevice.Viewport.Height - 25);
            #endregion
            #region sidebar
            Rectangle rectangle = new Rectangle((int)(GraphicsDevice.Viewport.Width * 0.8f),0,(int)(GraphicsDevice.Viewport.Width*0.2f),GraphicsDevice.Viewport.Height);
            sidebar = new Sidebar(rectangle);
            sidebar.LoadContent(Content);
            #endregion
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

            spawner.Update(sidebar);


            world.Step((float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f);

            base.Update(gameTime);
        }

        



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

                floor.Draw(spriteBatch);
                spawner.Draw(spriteBatch);


                sidebar.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
