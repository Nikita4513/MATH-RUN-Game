using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains_MATH_RUN.Domains
{
    public class VisitedPoint : ICreature
    {
        public string Name { get => "VisitedPoint"; }

        public Point Location { get; }

        public VisitedPoint(int x, int y)
        {
            Location = new Point(x, y);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var other = obj as VisitedPoint;
            return Name == other.Name
                && Location == other.Location;
        }
    }
}
