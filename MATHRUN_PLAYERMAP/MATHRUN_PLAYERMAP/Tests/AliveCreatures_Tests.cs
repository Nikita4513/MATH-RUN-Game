using Domains_MATH_RUN;
using MATHRUN_PLAYERMAP.Domains;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestFixture]
    class AliveCreatures_Tests
    {
        [Test]
        public static void SimplePLayerTest()
        {
            var field = new Field(Levels.AllLevels[0]);
            var playerLocation = field.GetLocationOf(typeof(Player));
            var creature = field.Map[playerLocation.X, playerLocation.Y];
            var player = creature as Player;
            var nextPoint = player.NextPoint;
            var excepted = new Point(6, 1);
            Assert.AreEqual(excepted, nextPoint);
        }

        [Test]
        public static void SimpleMonsterTest()
        {
            var field = new Field(Levels.AllLevels[0]);
            var monsterLocation = field.GetLocationOf(typeof(Player));
            var creature = field.Map[monsterLocation.X, monsterLocation.Y];
            var monster = creature as Monster;
            var nextPoint = monster.NextPoint;
            var excepted = new Point(6, 1);
            Assert.AreEqual(excepted, nextPoint);
        }
    }
}
