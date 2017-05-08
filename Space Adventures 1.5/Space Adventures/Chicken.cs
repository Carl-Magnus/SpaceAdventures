using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Adventures
{
    class Chicken : Enemy
    {
        private Vector2 startPos;
        private bool walkRight = true;

        public Chicken(Texture2D tex, Vector2 pos, Rectangle rect, GameWindow window) : base(tex, pos, rect, window)
        {
            startPos = pos;
        }

        public override void Update(GameTime gameTime)
        {
            if (pos.X <= startPos.X + chickenWalk && walkRight == true)
            {
                speed.X = 1;
                
                if (pos.X >= startPos.X + chickenWalk)
                {
                    walkRight = false;
                }
            }

            if (pos.X >= startPos.X - chickenWalk && walkRight == false)
            {
                speed.X = -1;

                if (pos.X <= startPos.X - chickenWalk)
                {
                    walkRight = true;
                }
            }

            hitBox.X = (int)pos.X;
            hitBox.Y = (int)(pos.Y >= 0 ? pos.Y + 1f : pos.Y - 1f);

            //Stay above ground
            if (hitBox.Y + hitBox.Height > bY)
            {
                pos.Y = bY - hitBox.Height;
                isOnGround = true;
                speed.Y = 0;
            }

            pos += speed;
            speed.Y += 0.2f;

            frameTimer -= timer / 3;

            //Animation av fiende
            if (speed.X == 1)
            {
                if (frameTimer <= 0)
                {
                    frame2 = 2;
                    rect.Y = (frame2 % 2) * rect.Height;

                    frameTimer = frameInterval;
                    frame++;
                    rect.X = (frame % 3) * rect.Width;
                }
            }
            else if (speed.X == -1)
            {
                if (frameTimer <= 0)
                {
                    frame2 = 1;
                    rect.Y = (frame2 % 2) * rect.Height;

                    frameTimer = frameInterval;
                    frame++;
                    rect.X = (frame % 3) * rect.Width;
                }
            }
        }
    }
}
