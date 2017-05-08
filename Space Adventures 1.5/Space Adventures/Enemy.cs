using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Adventures
{
    class Enemy : MovingObject
    {
        protected int chickenWalk = 100;

        public Enemy(Texture2D tex, Vector2 pos, Rectangle rect, GameWindow window) : base(tex, null, pos, rect, window)
        {
            this.tex = tex;
            this.rect = rect;

            hitBox = rect;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, rect, Color.White);
        }
    }
}
