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
    class MovingObject : GameObject
    {
        protected KeyboardState ks;
        protected GameWindow window;
        protected Vector2 speed;
        protected int bY, bX;
        protected bool isOnGround;

        protected int frame, frame2, timer = 20;
        protected double frameTimer = 150, frameInterval = 150;
        protected bool run = false;

        public MovingObject(Texture2D tex, Vector2 pos, Rectangle rect, GameWindow window) : base(tex, pos)
        {
            this.window = window;
            speed = new Vector2(0, 0);

            bX = window.ClientBounds.Width;
            bY = window.ClientBounds.Height;

            hitBox = new Rectangle((int)pos.X, (int)pos.Y, rect.Width, rect.Height);
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, Color.White);
        }

        public override void HandleCollision(Platform p)
        {
            isOnGround = true;
            speed.Y = 0;
            base.HandleCollision(p);
        }
    }
}
