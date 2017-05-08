using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Adventures
{
    class GameObject
    {
        protected Texture2D tex;
        protected Vector2 pos;
        protected Rectangle hitBox;

        protected Rectangle rect;

        public GameObject(Texture2D tex, Vector2 pos)
        {
            this.pos = pos;

            hitBox = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }

        public virtual bool IsColliding(Platform plat)
        {
            return hitBox.Intersects(plat.hitBox);
        }

        public virtual void HandleCollision(Platform other)
        {
            hitBox.Y = other.hitBox.Y - hitBox.Height;
            pos.Y = hitBox.Y;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch sb)
        {

        }
    }
}
