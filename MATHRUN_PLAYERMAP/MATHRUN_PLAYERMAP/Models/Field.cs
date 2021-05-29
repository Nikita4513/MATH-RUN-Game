using Domains_MATH_RUN.Domains;
using MATHRUN_PLAYERMAP.Domains;
using System;
using System.Drawing;
using System.Linq;

namespace Domains_MATH_RUN
{
    public class Field
    {
        public ICreature[,] Map { get; }
        public int Height { get => Map.GetLength(1); }
        public int Width { get => Map.GetLength(0); }

        public Field(Level level)
        {
            Map = CreateMap(level.Map);
        }

        public Point GetLocationOf(Type creatureType)
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    if (Map[x, y] == null)
                        continue;
                    if (Equals(Type.GetType(Map[x,y].ToString()), creatureType))
                        return new Point(x, y);
                }
            }
            throw new Exception("Player hasn't been found");
        }

        public bool CreatureOnMap(Type typeCreature)
        {
            try
            {
                this.GetLocationOf(typeCreature);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private ICreature[,] CreateMap(string map, string separator = "\r\n")
        {
            var rows = map.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            if (rows.Select(z => z.Length).Distinct().Count() != 1)
                throw new Exception($"Wrong test map '{map}'");
            var result = new ICreature[rows[0].Length, rows.Length];
            for (var x = 0; x < rows[0].Length; x++)
                for (var y = 0; y < rows.Length; y++)
                    result[x, y] = CreateCreatureBySymbol(rows[y][x], x, y); // or y, x
            return result;
        }

        private ICreature CreateCreatureBySymbol(char symbol, int x, int y)
        {
            switch (symbol)
            {
                case 'P':
                    return new Player(x, y, this); 
                case 'W':
                    return new Wall(x, y);
                case 'M':
                    return new Monster(x, y, this);
                case 'F':
                    return new Finish(x, y);
                case '.':
                    return new VisitedPoint(x, y);
                case ' ':
                    return null;
                default:
                    throw new Exception($"wrong character for ICreature {symbol}");
            }
        }
    }

    
}
