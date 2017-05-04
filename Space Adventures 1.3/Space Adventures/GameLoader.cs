using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Adventures
{
    class GameLoader
    {
        public Vector2 platformPos, playerPos;

        public GameLoader()
        {

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

                    platformPos = pos;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                }
            }
        }

        public void LoadPlayer()
        {
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

                    playerPos = pos;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                }
            }
        }

        public void Pos(Vector2 playerPos, Vector2 platformPos)
        {
            this.playerPos = playerPos;
            this.platformPos = platformPos;
        }
    }
}
