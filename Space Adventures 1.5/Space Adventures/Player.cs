using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Adventures
{
    class Player : MovingObject
    {
        Camera camera;

        Bullet bullet;
        Bullet2 bullet2;

        Texture2D bulletTex;

        Rectangle bulletRect;
        Vector2 velocity = new Vector2(10, 0);
        List<Bullet> bulletList = new List<Bullet>();
        List<Bullet2> bulletList2 = new List<Bullet2>();

        bool shootRight = true;
        bool shootUp = false;
        bool otherBullet;

        public Player(Texture2D tex, Texture2D bulletTex, Vector2 pos, Rectangle rect, GameWindow window, Camera camera) : base(tex, bulletTex, pos, rect, window)
        {
            this.tex = tex;
            this.bulletTex = bulletTex;
            this.window = window;
            this.camera = camera;
            this.rect = rect;
            //this.shootRight = shootRight;
            //this.shootUp = shootUp;

            bX = window.ClientBounds.Width;
            bY = window.ClientBounds.Height;
        }

        public override void Update(GameTime gameTime)
        {
            //Movement
            if (ks.IsKeyDown(Keys.Right) && (pos.X + rect.Width) <= 1800)
            {
                speed.X = 4;
                shootRight = true;

                //Animation, don't change the values, it won't work if you do
                if (frameTimer <= 0)
                {
                    frame2 = 2;
                    rect.Y = (frame2 % 2) * rect.Height;

                    frameTimer = frameInterval;
                    frame++;
                    rect.X = (frame % 6) * rect.Width;
                }

            }
            else if (ks.IsKeyDown(Keys.Left) && pos.X >= rect.Width)
            {
                speed.X = -4;
                shootRight = false;

                //Animation, don't change the values, it won't work if you do
                if (frameTimer <= 0)
                {
                    frame2 = 1;
                    rect.Y = (frame2 % 2) * rect.Height;

                    frameTimer = frameInterval;
                    frame++;
                    rect.X = (frame % 6) * rect.Width;
                }
            }

            if (pos.Y - rect.Height <= (800 - camera.levelBounds.Bottom))
            {
                speed.Y += 0.2f;
            }

            //Shoot upwards
            if (ks.IsKeyDown(Keys.Z))
            {
                shootUp = true;
            }
            else
            {
                shootUp = false;
            }

            //Jump
            if (ks.IsKeyDown(Keys.Up) && isOnGround)
            {
                speed.Y = -7;
                isOnGround = false;
                //shootUp = true;
            }
            //Stay above ground
            if (hitBox.Y + hitBox.Height > bY)
            {
                pos.Y = bY - hitBox.Height;
                isOnGround = true;
                speed.Y = 0;
            }

            if (ks.IsKeyDown(Keys.X))
            {
                otherBullet = !otherBullet;
            }

            oldks = ks;
            ks = Keyboard.GetState();

            //Shoots a bullet from the players gun            
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !oldks.IsKeyDown(Keys.Space))
            {
                if (otherBullet)
                {
                    bullet = new Bullet(bulletTex, bulletTex, new Vector2(pos.X + 15, pos.Y + 23), velocity, bulletRect, window, shootRight, shootUp);
                    bulletList.Add(bullet);
                }
                else
                {
                    bullet2 = new Bullet2(bulletTex, bulletTex, new Vector2(pos.X + 15, pos.Y + 23), velocity, bulletRect, window, shootRight, shootUp);
                    bulletList2.Add(bullet2);
                }

            }

            if (ks.IsKeyDown(Keys.B))
            {
                bullet = new Bullet(bulletTex, bulletTex, pos, velocity, bulletRect, window, shootRight, shootUp);
                bulletList.Add(bullet);
            }
            foreach (Bullet bullet in bulletList)
            {
                bullet.Update(gameTime);
            }
            foreach (Bullet2 bullet2 in bulletList2)
            {
                bullet2.Update(gameTime);
            }

            camera.SetPos(pos);

            pos += speed;
            speed.X = 0;
            speed.Y += 0.2f;

            frameTimer -= timer;

            hitBox.X = (int)pos.X;
            hitBox.Y = (int)(pos.Y >= 0 ? pos.Y + 0.9f : pos.Y - 0.9f);
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, rect, Color.White);

            foreach (Bullet bullet in bulletList)
            {
                bullet.Draw(sb);
            }
            foreach (Bullet2 bullet2 in bulletList2)
            {
                bullet2.Draw(sb);
            }
        }
    }
}
