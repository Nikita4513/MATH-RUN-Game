using Domains_MATH_RUN.Domains;
using System;
using System.Drawing;

namespace Domains_MATH_RUN
{
    public class Player : IAliveCreature
    {
        public string Name { get => "Player"; }
        public Field Field { get; }
        public Point Location { get; set; }
        public int Health { get; }
        public Point NextPoint { get => GetNextPoint(); }

        public Player(int x, int y, Field field)
        {
            Field = field;
            Location = new Point(x, y);
        }

        public void MoveNext()
        {
            var nextPoint = this.GetNextPoint();
            if (nextPoint.X == int.MaxValue)
                return;
            Field.Map[NextPoint.X, NextPoint.Y] = Field.Map[Location.X, Location.Y];
            Field.Map[Location.X, Location.Y] = new VisitedPoint(Location.X, Location.Y);
            Location = nextPoint;
        }

        private Point GetNextPoint()
        {
            var x = Location.X;
            var y = Location.Y;

            for (var dx = -1; dx <= 1; dx++)
            {
                for (var dy = -1; dy <= 1; dy++)
                {
                    if (dx != 0 || dy != 0)
                    {
                        if (x + dx >= 0 && x + dx < Field.Width
                         && y + dy >= 0 && y + dy < Field.Height)
                        {
                            if (CreaturesEqual(Field.Map[x + dx, y + dy], new Finish(0, 0)))
                                return new Point(x + dx, y + dy);
                            if (Field.Map[x + dx, y + dy] == null)
                                return new Point(x + dx, y + dy);
                        }
                    }
                }
            }
            return new Point(int.MaxValue, int.MaxValue);

            throw new Exception("There is no next move");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var otherPlayer = obj as Player;
            return Name == otherPlayer.Name
                && Field.Equals(otherPlayer.Field)
                && Location == otherPlayer.Location
                && Health == otherPlayer.Health;
        }

        private bool CreaturesEqual(ICreature creature, ICreature another)
        {
            if (another == null || creature == null)
                return false;
            return creature.Name == another.Name;
        }
    }
}
