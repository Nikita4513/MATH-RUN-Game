using Domains_MATH_RUN.Domains;
using System;
using System.Drawing;

namespace Domains_MATH_RUN
{
    public class Monster : IAliveCreature
    {
        public string Name { get => "Monster"; }
        public Point Location { get; private set; }
        public Field Field { get; }
        public Point NextPoint { get => GetNextPoint(); }
        public Monster(int x, int y, Field field)
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
            Field.Map[Location.X, Location.Y] = null;
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
                            if (CreaturesEqual(Field.Map[x + dx, y + dy], new Player(0, 0, Field)))
                                return new Point(x + dx, y + dy);
                            if (CreaturesEqual(Field.Map[x + dx, y + dy], new VisitedPoint(0, 0)))
                                return new Point(x + dx, y + dy);
                        }
                    }
                }
            }
            return new Point(int.MaxValue, int.MaxValue);
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
        
        private bool CreaturesEqual(ICreature creature, ICreature another)
        {
            if (another == null || creature == null)
                return false;
            return creature.Name == another.Name;
        }   
    }




}
