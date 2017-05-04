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
    class Bullet
    {
        Texture2D tex;

        Vector2 pos;
        Vector2 startPos;
        Vector2 velocity;

        Rectangle hitBox;

        float bulletSpeed;

        public bool isVisible;

        const int maxDistance = 500;

        public Bullet(Texture2D tex, Vector2 startPos, Vector2 velocity, Rectangle hitBox)
        {
            this.tex = tex;
            this.startPos = startPos;
            this.velocity = velocity;
            this.hitBox = hitBox;

            isVisible = false;
        }

        public void Update()
        {
            if(Vector2.Distance(startPos, pos) > maxDistance)
            {
                isVisible = false;
            }

            if(isVisible == true)
            {
                bulletSpeed = 20;
                pos = startPos + velocity;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            if(isVisible == true)
            {
                sb.Draw(tex, pos, Color.White);
            }
        }

    }
}
