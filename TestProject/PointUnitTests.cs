using System;
using System.Collections.Generic;
using NUnit.Framework;
using PizzaDeliveryBot;

namespace UnitTests
{
    [TestFixture]
    public class PointUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InitializedWithCorrectData_ReturnCorrectData()
        {
            Point point = new Point(43, 565);

            Assert.AreEqual(43, point.X);
            Assert.AreEqual(565, point.Y);
        }
    }
}
