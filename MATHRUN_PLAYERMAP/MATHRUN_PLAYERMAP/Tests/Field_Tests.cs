using Domains_MATH_RUN;
using Domains_MATH_RUN.Domains;
using MATHRUN_PLAYERMAP.Domains;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Drawing;
//using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestProject1
{
    [TestFixture]
    public class Field_Tests
    {
        [Test]
        public static void SimpleFieldTest()
        {
            var field = new Field(Levels.AllLevels[0]);
            var playerLocation = field.GetLocationOf(typeof(Player));
            var monsterLocation = field.GetLocationOf(typeof(Monster));
            var exceptedPlayerLocation = new Point(5, 1);
            var exceptedMonsterLocation = new Point(1, 1);
            Assert.AreEqual(playerLocation, exceptedPlayerLocation);
            Assert.AreEqual(monsterLocation, exceptedMonsterLocation);
        }

        //[Test]
        //public static void GetLocationOfUnknownCreature_ShouldThrowException()
        //{
        //    var field = new Field(Levels.AllLevels[0]);
        //    Action act = () => field.GetLocationOf(typeof(string));
        //    Assert.ThrowsException<Exception>(act);
        //}

        [Test]
        public static void InitializingField()
        {
            var someMap = @"
PWM .F";
            var someLevel = new Level(someMap, Difficulty.Easy);
            var field = new Field(someLevel);
            var creaturesField = new ICreature[]
            {
                new Player(0, 0, field),
                new Wall(1, 0),
                new Monster(2, 0, field),
                null,
                new VisitedPoint(4, 0),
                new Finish(5, 0)
            };
            for (var x = 0; x < field.Width; x++)
                if (x == 3)
                    Assert.IsTrue(field.Map[x, 0] == null);
                else
                    Assert.IsTrue(field.Map[x, 0].Equals(creaturesField[x]));
            
        }
    }
}
