using System.Drawing;

namespace Domains_MATH_RUN
{
    public class Wall : ICreature
    {
        public string Name { get => "Wall"; }
        public Point Location { get; }

        public Wall(int x, int y)
        {
            Location = new Point(x, y);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var otherWall = obj as Wall;
            if (otherWall == null)
                return false;
            return Name == otherWall.Name
                && Location == otherWall.Location;
        }
    }
}
