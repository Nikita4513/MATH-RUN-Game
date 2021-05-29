using Domains_MATH_RUN;
using NUnit.Framework;

namespace Domains_MATH_RUN
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            var field = new Field(Levels.AllLevels[0]);
            var playerLocation = field.GetLocationOf(typeof(Player));
            var creature = field.Map[playerLocation.X, playerLocation.Y];
            var player = creature as Player;
            var nextPoint = player.NextPoint;
            var excepted = new Point(6, 1);
            Assert.AreEqual(excepted, nextPoint);
        }
    }
}