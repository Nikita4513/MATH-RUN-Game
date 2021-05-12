using Domains_MATH_RUN;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATHRUN_PLAYERMAP.Controllers
{
    class GameController
    {
        public Game Game { get; }
        public int CellSize { get => 50; }

        public GameController()
        {
            Game = new Game();
        }

        public void DrawMap(Graphics g)
        {
            for (var x = 0; x < Game.Field.Width; x++)
            {
                for (var y = 0; y < Game.Field.Height; y++)
                {
                    if (Game.Field.Map[x, y] != null && Game.Field.Map[x, y].Name == "Wall")
                    {
                        var wallImage = Resource.wall;
                        g.DrawImage(new Bitmap(wallImage, new Size(CellSize, CellSize)), x * CellSize, y * CellSize);
                    }
                    if (Game.Field.Map[x, y] != null && Game.Field.Map[x, y].Name == "Finish")
                    {
                        var finishImage = Resource.finish;
                        g.DrawImage(new Bitmap(finishImage, new Size(CellSize, CellSize)), x * CellSize, y * CellSize);
                    }
                    if (Game.Field.Map[x, y] != null && Game.Field.Map[x, y].Name == "Player")
                    {
                        var playerImage = Resource.player;
                        g.DrawImage(new Bitmap(playerImage, new Size(CellSize, CellSize)), x * CellSize, y * CellSize);
                    }
                    if (Game.Field.Map[x, y] != null && Game.Field.Map[x, y].Name == "Monster")
                    {
                        var monsterImage = Resource.monster;
                        g.DrawImage(new Bitmap(monsterImage, new Size(CellSize, CellSize)), x * CellSize, y * CellSize);
                    }
                }
            }
        }

        public void DrawQuestion(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Red), new Rectangle(new Point(10, 10), new Size(10, 10)));
        }


    }
}
