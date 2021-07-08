using System;
using System.Collections.Generic;
using NUnit.Framework;
using PizzaDeliveryBot;

namespace UnitTests
{
    [TestFixture]
    public class FieldUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InitializedWithCorrectData_ReturnCorrectData()
        {
            var points = new List<Point>();
            Field field = new Field(200, 20, points);

            Assert.AreEqual(200, field.FieldWidth);
            Assert.AreEqual(20, field.FieldHeight);
            Assert.AreEqual(points, field.PointsToVisit);
        }

        [Test]
        public void InitializedWithIncorrectWidth_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => { Field field = new Field(-300, 20, new List<Point>()); });
        }

        [Test]
        public void InitializedWithIncorrectHeight_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => { Field field = new Field(300, -30, new List<Point>()); });
        }

        [Test]
        public void InitializedWithIncorrectPoints_ThrowArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => { Field field = new Field(300, 30, null); });
        }
    }
}