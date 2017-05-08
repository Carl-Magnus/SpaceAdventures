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
    class Platform : GameObject
    {
        public Platform(Texture2D tex, Vector2 pos, Rectangle hitBox) : base(tex, pos)
        {
            this.tex = tex;
            this.pos = pos;
            this.hitBox = hitBox;
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, hitBox, Color.White);
        }
    }
}
