using Domains_MATH_RUN.Domains;
using System;
using System.Drawing;

namespace Domains_MATH_RUN
{
    public class Monster : IAliveCreature
    {
        public string Name { get => "Monster"; }
        public Point Location { get; }
        public Field Field { get; }
        public Point NextPoint { get => GetNextPoint(); }
        public Monster(int x, int y, Field field)
        {
            Field = field;
            Location = new Point(x, y);
        }

        public void MoveNext()
        {
            throw new NotImplementedException();
        }


        private Point GetNextPoint()
        {
            var x = Location.X;
            var y = Location.Y;

            for (var dx = -1; dx <= 1; dx++)
            {
                for (var dy = -1; dy <= 1; dy++)
                {
                    if (dx != 0 && dy != 0)
                        if (x + dx >= 0 && x + dx < Field.Width
                             && y + dy >= 0 && y + dy < Field.Height)
                            if (Equals(Field.Map[x + dx, y + dy], typeof(VisitedPoint)))
                                return new Point(x + dx, y + dy);
                }
            }

            throw new Exception("There is no next move");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var otherMonster = obj as Monster;
            return Name == otherMonster.Name
                && Field.Equals(otherMonster.Field)
                && Location == otherMonster.Location;
        }

        
    }




}
