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
                    if (Game.Field.Map[x, y] != null && Game.Field.Map[x, y].Name == "Player")
                    {
                        var playerImage = new Bitmap("C:\\Users\\DNS\\Documents\\GitHub\\MATH-RUN_MAIN\\MATHRUN_PLAYERMAP\\MATHRUN_PLAYERMAP\\Sprites\\Player\\player_01.png");
                        g.DrawImage(new Bitmap(playerImage, new Size(CellSize, CellSize)), x*CellSize, y*CellSize);
                    }
                    if (Game.Field.Map[x, y] != null && Game.Field.Map[x, y].Name == "Monster")
                    {
                        var playerImage = new Bitmap("C:\\Users\\DNS\\Documents\\GitHub\\MATH-RUN_MAIN\\MATHRUN_PLAYERMAP\\MATHRUN_PLAYERMAP\\Sprites\\Monster\\monster_01.png");
                        g.DrawImage(new Bitmap(playerImage, new Size(CellSize, CellSize)), x * CellSize, y * CellSize);
                    }
                    if (Game.Field.Map[x, y] != null && Game.Field.Map[x, y].Name == "Wall")
                    {
                        var playerImage = new Bitmap("C:\\Users\\DNS\\Documents\\GitHub\\MATH-RUN_MAIN\\MATHRUN_PLAYERMAP\\MATHRUN_PLAYERMAP\\Sprites\\Blocks\\Block_01.png");
                        g.DrawImage(new Bitmap(playerImage, new Size(CellSize, CellSize)), x * CellSize, y * CellSize);
                    }
                    if (Game.Field.Map[x, y] != null && Game.Field.Map[x, y].Name == "Finish")
                    {
                        var playerImage = new Bitmap("C:\\Users\\DNS\\Documents\\GitHub\\MATH-RUN_MAIN\\MATHRUN_PLAYERMAP\\MATHRUN_PLAYERMAP\\Sprites\\Ground\\Ground_06.png");
                        g.DrawImage(new Bitmap(playerImage, new Size(CellSize, CellSize)), x * CellSize, y * CellSize);
                    }
                }
            }
        }

    }
}
