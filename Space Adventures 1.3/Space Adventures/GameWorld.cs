using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Space_Adventures
{
    class GameWorld
    {
        GameWindow window;
        GameLoader gameLoader;

        Texture2D playerTex;
        Texture2D platTex;
        Texture2D backgroundTex;
        Texture2D chickenTex;

        Player player;
        Platform plat;
        Chicken chicken;
        Background backGround;

        Camera camera;

        List<Platform> platList = new List<Platform>();

        List<Enemy> chickenList = new List<Enemy>();

        public GameWorld(Texture2D playerTex, Texture2D platTex, Texture2D backgroundTex, Texture2D chickenTex, GameWindow window, Camera camera)
        {
            this.playerTex = playerTex;
            this.platTex = platTex;
            this.backgroundTex = backgroundTex;
            this.chickenTex = chickenTex;
            this.window = window;
            this.camera = camera;

            LoadPlatforms();
            LoadPlayer();

            //Enemies
            LoadChicken();
        }

        public virtual void Update(GameTime gameTime)
        {
            player.Update(gameTime);

            foreach (Platform plat in platList)
            {
                if (player.IsColliding(plat))
                {
                    player.HandleCollision(plat);
                }

                foreach (Chicken c in chickenList)
                {
                    if (c.IsColliding(plat))
                    {
                        c.HandleCollision(plat);
                    }
                }
            }

            foreach (Chicken c in chickenList)
            {
                c.Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch sb)
        {
            //sb.Draw(backgroundTex, Vector2.Zero, Color.White);

            player.Draw(sb);

            foreach (Platform plat in platList)
            {
                plat.Draw(sb);
            }

            foreach (Chicken chick in chickenList)
            {
                chick.Draw(sb);
            }
        }

        public void LoadPlatforms()
        {
            StreamReader sr = new StreamReader("Platforms.txt");
            string s = sr.ReadLine();
            string[] coodinates = s.Split(';');
            for (int i = 0; i < coodinates.Length; i++)
            {
                string[] xywh = coodinates[i].Split(',');
                try
                {
                    int x = Convert.ToInt32(xywh[0]);
                    int y = Convert.ToInt32(xywh[1]);
                    int w = Convert.ToInt32(xywh[2]);
                    int h = Convert.ToInt32(xywh[3]);
                    Vector2 pos = new Vector2(x, y);
                    Rectangle rect = new Rectangle(x, y, w, h);
                    Console.WriteLine("" + pos);

                    plat = new Platform(platTex, pos, rect);
                    platList.Add(plat);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                }
            }
        }

        public void LoadPlayer()
        {
            Rectangle playerRect = new Rectangle(0, 0, 34, 47);

            StreamReader sr = new StreamReader("Player.txt");
            string s = sr.ReadLine();
            string[] coodinates = s.Split(';');
            for (int i = 0; i < coodinates.Length; i++)
            {
                string[] xywh = coodinates[i].Split(',');
                try
                {
                    int x = Convert.ToInt32(xywh[0]);
                    int y = Convert.ToInt32(xywh[1]);
                    Vector2 pos = new Vector2(x, y);

                    Console.WriteLine("" + pos);

                    player = new Player(playerTex, pos, playerRect, window, camera);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                }
            }
        }

        public void LoadChicken()
        {
            Rectangle chickenRect = new Rectangle(0, 0, 27, 23);

            StreamReader sr = new StreamReader("Enemy.txt");
            string s = sr.ReadLine();
            string[] coodinates = s.Split(';');
            for (int i = 0; i < coodinates.Length; i++)
            {
                string[] xywh = coodinates[i].Split(',');
                try
                {
                    int x = Convert.ToInt32(xywh[0]);
                    int y = Convert.ToInt32(xywh[1]);
                    Vector2 pos = new Vector2(x, y);

                    Console.WriteLine("" + pos);

                    chicken = new Chicken(chickenTex, pos, chickenRect, window);
                    chickenList.Add(chicken);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                }
            }
        }
    }
}
