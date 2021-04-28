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
            if (Field.Map[nextPoint.X, nextPoint.Y] == null)
            {
                Field.Map[Location.X, Location.Y] = new VisitedPoint(Location.X, Location.Y);
                Field.Map[nextPoint.X, nextPoint.Y] = new Player(nextPoint.X, nextPoint.Y, Field);
            }
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
                        if (x + dx >= 0 && x + dx < Field.Width
                             && y + dy >= 0 && y + dy < Field.Height)
                            if (Field.Map[x + dx, y + dy] == null)
                                return new Point(x + dx, y + dy);
                }
            }

            throw new Exception("There is no next move");
        }

        private void Swap(Point current, Point next)
        {
            
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
    }




}
