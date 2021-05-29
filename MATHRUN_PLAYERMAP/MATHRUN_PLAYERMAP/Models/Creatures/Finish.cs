using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains_MATH_RUN.Domains
{
    public class Finish : ICreature
    {
        public string Name { get => "Finish"; }
        public Point Location { get; }

        public Finish(int x, int y)
        {
            Location = new Point(x, y);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var otherFinish = obj as Finish;
            return Name == otherFinish.Name
                && Location == otherFinish.Location;
        }
    }
}
