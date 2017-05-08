using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Adventures
{
    class Background
    {
        List<Vector2> foreGround, middleGround, backGround;
        Texture2D[] tex;
        GameWindow window;

        int fgSpacing, mgSpacing, bgSpacing;
        float fgSpeed, mgSpeed, bgSpeed;

        public Background(ContentManager Content, GameWindow window)
        {
            this.tex = new Texture2D[3];
            this.window = window;

            tex[0] = Content.Load<Texture2D>("DesertFG");
            tex[1] = Content.Load<Texture2D>("DesertMG");
            tex[2] = Content.Load<Texture2D>("DesertBG");

            foreGround = new List<Vector2>();
            fgSpacing = tex[0].Width;
            fgSpeed = 0.1f;

            for (int i = 0; i < (window.ClientBounds.Width / fgSpacing) + 2; i++)
            {
                foreGround.Add(new Vector2(i * fgSpacing, window.ClientBounds.Height));
            }

            middleGround = new List<Vector2>();
            mgSpacing = window.ClientBounds.Width / 5;
            mgSpeed = 0.25f;

            for (int i = 0; i < (window.ClientBounds.Width / mgSpacing) + 2; i++)
            {
                middleGround.Add(new Vector2(i * mgSpacing, window.ClientBounds.Height - tex[1].Height));
            }

            backGround = new List<Vector2>();
            bgSpacing = window.ClientBounds.Width / 3;
            bgSpeed = 0.50f;

            for (int i = 0; i < (window.ClientBounds.Width / bgSpacing) + 2; i++)
            {
                backGround.Add(new Vector2(i * bgSpacing, window.ClientBounds.Height - tex[0].Height));
            }
        }

        public void Update()
        {
            //for (int i = 0; i < foreGround.Count; i++)
            //{
            //    foreGround[i] = new Vector2(foreGround[i].X - fgSpeed, foreGround[i].Y);
            //    if(foreGround[i].X <= -fgSpacing)
            //    {
            //        int j = i - 1;
            //        if(j < 0)
            //        {
            //            j = foreGround.Count - 1;
            //        }
            //        foreGround[i] = new Vector2(foreGround[j].X + fgSpacing - 1, foreGround[i].Y);
            //    }
            //}

            //for (int i = 0; i < middleGround.Count; i++)
            //{
            //    middleGround[i] = new Vector2(middleGround[i].X - mgSpeed, middleGround[i].Y);
            //    if(middleGround[i].X <= -mgSpacing)
            //    {
            //        int j = i - 1;
            //        if(j < 0)
            //        {
            //            j = middleGround.Count - 1;
            //        }
            //        middleGround[i] = new Vector2(middleGround[j].X + mgSpacing - 1, middleGround[i].Y);
            //    }
            //}

            for (int i = 0; i < backGround.Count; i++)
            {
                backGround[i] = new Vector2(backGround[i].X - bgSpeed, backGround[i].Y);
                if (backGround[i].X <= -bgSpacing)
                {
                    int j = i - 1;
                    if (j < 0)
                    {
                        j = backGround.Count - 1;
                    }
                    backGround[i] = new Vector2(backGround[j].X + bgSpacing - 1, backGround[i].Y);
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Vector2 v in backGround)
            {
                sb.Draw(tex[2], v, Color.White);
            }
            foreach (Vector2 v in middleGround)
            {
                sb.Draw(tex[1], v, Color.White);
            }
            foreach (Vector2 v in foreGround)
            {
                sb.Draw(tex[0], v, Color.White);
            }
        }
    }
}
