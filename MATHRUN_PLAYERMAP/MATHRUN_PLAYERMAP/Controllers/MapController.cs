using Domains_MATH_RUN;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATHRUN_PLAYERMAP.Controllers
{
    public static class MapController
    {
        public static Field field { get; private set; }
        public static int Width { get => field.Width; }
        public static int Height { get => field.Width; }
        public static Image spriteSheet;
        public static int cellSize = 31;

        public static void Initialize(string Level)
        {
            field = new Field(Level);
        }

        public static void SeedMap(Graphics g)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (field.Map[i, j] == null)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize),
                            new Size(cellSize * 3, cellSize * 3)), 202, 298, 107, 114, GraphicsUnit.Pixel);
                    }
                    if (field.Map[i, j] is Player)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize),
                            new Size(20, 12)), 581, 114, 19, 11, GraphicsUnit.Pixel);
                    }
                    if (field.Map[i, j] is Wall)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize),
                            new Size(20, 18)), 453, 225, 18, 22, GraphicsUnit.Pixel);
                    }
                }
            }
        }//доделать метод

        public static void DrawMap(Graphics g)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize * 3, cellSize * 3)), 202, 298, 107, 114, GraphicsUnit.Pixel);
                }
            }
        }
    }
}
