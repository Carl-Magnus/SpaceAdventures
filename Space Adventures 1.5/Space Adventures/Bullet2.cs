using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Space_Adventures
{
    class Bullet2 : MovingObject
    {
        //Texture2D tex;

        //Vector2 pos;
        Vector2 startPos;
        Vector2 velocity;
        Vector2 bulletCentrum;

        //Rectangle hitBox;

        bool shootRight = true;
        bool shootUp = false;
        double direction;

        //Texture2D bulletTex;

        public Bullet2(Texture2D tex, Texture2D bulletTex, Vector2 startPos, Vector2 velocity, Rectangle hitBox, GameWindow window, bool shootRight, bool shootUp) : base(tex, bulletTex, startPos, hitBox, window)
        {
            this.tex = tex;
            this.startPos = startPos;
            this.velocity = velocity;
            this.hitBox = hitBox;
            this.shootRight = shootRight;
            this.shootUp = shootUp;

            shootRight = true;
            shootUp = false;
        }

        public override void Update(GameTime gameTime)
        {
            bulletCentrum = new Vector2(0, tex.Height);
            if (shootRight && !shootUp)
            {
                direction = 1;
                startPos.X += 5 * (float)direction;
            }
            else if (!shootUp)
            {
                direction = -1;
                startPos.X += 5 * (float)direction;
            }
            if (shootUp)
            {
                startPos.Y -= 5;
            }

            hitBox = new Rectangle((int)startPos.X, (int)startPos.Y, tex.Width, tex.Height);
        }

        public override void Draw(SpriteBatch sb)
        {
            if (!shootRight && !shootUp)
            {
                sb.Draw(tex, startPos, null, Color.White, 3.2f, bulletCentrum, 1f, SpriteEffects.None, 1f);
            }
            else if (!shootUp)
            {
                sb.Draw(tex, hitBox, Color.White);
            }

            if (shootUp)
            {
                sb.Draw(tex, startPos, null, Color.White, 4.7f, bulletCentrum, 1f, SpriteEffects.None, 1f);
            }
        }

    }
}
