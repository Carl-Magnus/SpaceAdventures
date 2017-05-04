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

        public Player(Texture2D tex, Vector2 pos, Rectangle rect, GameWindow window, Camera camera) : base(tex, pos, rect, window)
        {
            this.tex = tex;
            this.window = window;
            this.camera = camera;
            this.rect = rect;

            bX = window.ClientBounds.Width;
            bY = window.ClientBounds.Height;
        }

        public override void Update(GameTime gameTime)
        {
            ks = Keyboard.GetState();

            //Movement
            if (ks.IsKeyDown(Keys.D) && (pos.X + rect.Width) < bX)
            {
                speed.X = 3;

                //Animation, don't change the values, it won't work if you do
                if (frameTimer <= 0)
                {
                    frame2 = 4;
                    rect.Y = (frame2 % 2) * rect.Height;

                    frameTimer = frameInterval;
                    frame++;
                    rect.X = (frame % 6) * rect.Width;
                }

            }
            else if (ks.IsKeyDown(Keys.A) && (pos.X) > 0)
            {
                speed.X = -3;

                //Animation, don't change the values, it won't work if you do
                if (frameTimer <= 0)
                {
                    frame2 = 1;
                    rect.Y = (frame2 % 4) * rect.Height;

                    frameTimer = frameInterval;
                    frame++;
                    rect.X = (frame % 6) * rect.Width;
                }
            }

            if (!isOnGround)
            {
                rect.X = (3 % 6) * rect.Width;
            }

            //Jump
            if (ks.IsKeyDown(Keys.Space) && isOnGround)
            {
                speed.Y = -7;
                isOnGround = false;
            }

            //Stay above ground
            if (hitBox.Y + hitBox.Height > bY)
            {
                pos.Y = bY - hitBox.Height;
                isOnGround = true;
                speed.Y = 0;
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

        }
    }
}
