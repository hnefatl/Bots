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

namespace Bots
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics { get; set; }
        public SpriteBatch spriteBatch { get; set; }

        protected SpriteFont Font { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.GameBounds = GraphicsDevice.Viewport.Bounds;

            Font = Content.Load<SpriteFont>(Resources.Font);

            BulletManager.Initialise(1.0f, Content.Load<Texture2D>(Resources.Bullet), 0.1f);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            MouseState State = Mouse.GetState();
            if (State.LeftButton == ButtonState.Pressed)
            {
                BulletManager.AddBullet(new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2),
                    new Vector2(State.X, State.Y));
            }

            BulletManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            if (Constants.Debug)
            {
                spriteBatch.Begin();

                spriteBatch.DrawString(Font, Convert.ToString(1 / (float)gameTime.ElapsedGameTime.TotalSeconds), new Vector2(0, 0), Color.Black);

                if (Constants.ShowBulletCount)
                {
                    spriteBatch.DrawString(Font, "Bullets: " + Convert.ToString(BulletManager.Bullets.Count), new Vector2(0, 20), Color.Black);
                }


                spriteBatch.End();
            }

            BulletManager.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
