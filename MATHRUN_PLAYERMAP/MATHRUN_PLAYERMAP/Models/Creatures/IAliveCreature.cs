using System.Drawing;

namespace Domains_MATH_RUN
{
    interface IAliveCreature : ICreature
    {
        public Point NextPoint { get; }
        public void MoveNext();
    }

}
