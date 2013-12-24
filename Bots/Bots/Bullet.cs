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

namespace Bots
{
    public class Bullet
    {
        #region Static Members
        /// <summary>
        /// The image used for every Bullet
        /// </summary>
        public static Texture2D Image { get; set; }

        /// <summary>
        /// The origin to rotate the image around
        /// </summary>
        public static Vector2 RotationOrigin { get; set; }

        /// <summary>
        /// The speed every Bullet travels at
        /// </summary>
        public static float Speed { get; set; }

        /// <summary>
        /// The damage every Bullet inflicts
        /// </summary>
        public static float Damage { get; set; }
        #endregion

        #region Members
        /// <summary>
        /// The position of the Bullet
        /// </summary>
        public Vector2 Position { get; set; }
        /// <summary>
        /// The Rotation of the bullet, in radians
        /// </summary>
        public float Rotation { get; set; }
        /// <summary>
        /// Whether the Bullet is active (whether it needs destructing)
        /// </summary>
        public bool Active { get; set; }
        #endregion

        protected Bullet()
        {
            Active = true;
        }

        #region Factory Methods
        /// <summary>
        /// Creates a Bullet, calculating the Rotation
        /// </summary>
        /// <param name="Origin">The position at which the Bullet should start</param>
        /// <param name="Destination">The position to which the Bullet is heading</param>
        /// <returns>A new Bullet</returns>
        public static Bullet CreateBullet(Vector2 Origin, Vector2 Destination)
        {
            Bullet New = new Bullet();
            New.Position = Origin;
            New.Rotation = MathHelper.ToRadians((float)(Math.Atan2(Destination.Y - Origin.Y, Destination.X - Origin.X) * 180.0f / Math.PI) + 90);

            return New;
        }
        /// <summary>
        /// Creates a Bullet, setting the Rotation
        /// </summary>
        /// <param name="Origin">The position at which the Bullet should start</param>
        /// <param name="Angle">The angle the Bullet is heading in</param>
        /// <returns>A new Bullet</returns>
        public static Bullet CreateBullet(Vector2 Origin, float Angle)
        {
            Bullet New = new Bullet();
            New.Position = Origin;
            New.Rotation = MathHelper.ToRadians(Angle);

            return New;
        }
        #endregion

        /// <summary>
        /// Updates the Bullet (moves it)
        /// </summary>
        /// <param name="Time">The current GameTime</param>
        public void Update(GameTime Time)
        {
            float InternalAngle = (float)Math.PI - Rotation;
            Vector2 NewPosition;
            double DeltaSpeed = (double)Speed * Time.ElapsedGameTime.TotalMilliseconds;
            NewPosition.X = Position.X + (float)(DeltaSpeed * Math.Sin((double)InternalAngle));
            NewPosition.Y = Position.Y + (float)(DeltaSpeed * Math.Cos((double)InternalAngle));

            Position = NewPosition;

            if (!Globals.GameBounds.Intersects(new Rectangle((int)Position.X, (int)Position.Y, Image.Width, Image.Height)))
            {
                Active = false;
            }
        }

        /// <summary>
        /// Renders the Bullet
        /// </summary>
        /// <param name="Batch">The SpriteBatch to draw the bullet to</param>
        public void Draw(SpriteBatch Batch)
        {
            Batch.Begin();

            Batch.Draw(Image, Position, null, Color.White, Rotation, RotationOrigin, 1.0f, SpriteEffects.None, 0.0f);

            Batch.End();
        }
    }
}
