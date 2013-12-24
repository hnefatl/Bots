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
    public class BulletManager
    {
        /// <summary>
        /// A list of all Bullet objects created
        /// </summary>
        public static List<Bullet> Bullets { get; set; }

        /// <summary>
        /// Initialises the manager
        /// </summary>
        /// <param name="BulletDamage">The damage done by a Bullet</param>
        /// <param name="BulletTexture">The Texture used for Bullets</param>
        /// <param name="BulletSpeed">The speed of the Bullets</param>
        public static void Initialise(float BulletDamage, Texture2D BulletTexture, float BulletSpeed)
        {
            Bullets = new List<Bullet>();

            Bullet.Damage = BulletDamage;
            Bullet.Image = BulletTexture;
            Bullet.Speed = BulletSpeed;
        }

        /// <summary>
        /// Add a Bullet to the manager
        /// </summary>
        /// <param name="Origin">The original position</param>
        /// <param name="Destination">Where the Bullet is headed</param>
        public static void AddBullet(Vector2 Origin, Vector2 Destination)
        {
            Bullets.Add(Bullet.CreateBullet(Origin, Destination));
        }
        /// <summary>
        /// Add a Bullet to the manager
        /// </summary>
        /// <param name="Origin">The original position</param>
        /// <param name="Angle">The bearing the bullet is headed on</param>
        public static void AddBullet(Vector2 Origin, float Angle)
        {
            Bullets.Add(Bullet.CreateBullet(Origin, Angle));
        }

        /// <summary>
        /// Updates each Bullet
        /// </summary>
        /// <param name="Time">The current GameTime</param>
        public static void Update(GameTime Time)
        {
            for (int x = 0; x < Bullets.Count; x++)
            {
                Bullets[x].Update(Time);
                if (!Bullets[x].Active)
                {
                    Bullets.RemoveAt(x);
                    x--; // Account for one less object
                }
            }
        }

        /// <summary>
        /// Draws all Bullets
        /// </summary>
        /// <param name="Batch">The SpriteBatch to render the Bullets to</param>
        public static void Draw(SpriteBatch Batch)
        {
            for (int x = 0; x < Bullets.Count; x++)
            {
                Bullets[x].Draw(Batch);
            }
        }
    }
}
