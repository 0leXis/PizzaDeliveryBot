using System;
using System.Collections.Generic;
using NUnit.Framework;
using PizzaDeliveryBot;

namespace UnitTests
{
    class StringFieldProviderCorrectDataUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetField_InitializedWithCorrectData_ReturnCorrectData()
        {
            var points = new List<Point>()
            {
                new Point(0, 0),
                new Point(1, 3),
                new Point(4, 4),
                new Point(4, 2)
            };
            StringFieldProvider provider = new StringFieldProvider("5x6 (0, 0) (1, 3) (4, 4) (4, 2)");
            IField field = provider.GetField();

            Assert.AreEqual(5, field.FieldWidth);
            Assert.AreEqual(6, field.FieldHeight);
            Assert.AreEqual(points, field.PointsToVisit);
        }

        [Test]
        public void GetField_InitializedWithoutPoints_ReturnCorrectData()
        {
            var points = new List<Point>();
            StringFieldProvider provider = new StringFieldProvider("5x6");
            IField field = provider.GetField();

            Assert.AreEqual(5, field.FieldWidth);
            Assert.AreEqual(6, field.FieldHeight);
            Assert.AreEqual(points, field.PointsToVisit);
        }
    }

    //Incorrect format
    [TestFixture("5V6 (0, 0) (1, 3) (4, 4) (4, 2)")]
    [TestFixture("5x6 (0, 0) (1, 3) (4, 4) (4,2)")]
    [TestFixture("5x 6 (0, 0) (1, 3) (4, 4) (4,2)")]
    [TestFixture("5x6 (0, 0) (1, 3) (4, 4) (4,2 )")]
    [TestFixture("5x6 (0, 0)        (1, 3) (4, 4) (4,2)")]
    [TestFixture("5x6 (0, 0) (1, 3) (4, 4)(4, 2)")]
    [TestFixture("5x6 (0 0) (1, 3) (4, 4) (4, 2)")]
    [TestFixture("5x6 (0, 0) (1, 3 (4, 4) (4, 2)")]
    //Overflow
    [TestFixture("5x60000000000000000 (0, 0) (1, 3) (4, 4) (4, 2)")]
    [TestFixture("500000000000000000000x6 (0, 0) (1, 3) (4, 4) (4, 2)")]
    [TestFixture("5x6 (0, 0) (1, 3) (4, 4) (4, 200000000000000000000)")]
    [TestFixture("5x6 (0, 0) (1, 3) (4, 4) (4000000000000000000000000, 2)")]
    //Incorrect field size
    [TestFixture("0x0")]
    [TestFixture("0x1")]
    [TestFixture("1x0")]
    [TestFixture("-2x5")]
    [TestFixture("-2x-5")]
    [TestFixture("2x-5")]
    //Points out of bounds
    [TestFixture("5x6 (0, 0) (1, 10) (4, 4) (4, 2)")]
    [TestFixture("5x6 (0, 0) (1, 3) (20, 4) (4, 2)")]
    class StringFieldProviderIncorrectDataUnitTests
    {
        private string _inputString;

        public StringFieldProviderIncorrectDataUnitTests(string inputString)
        {
            _inputString = inputString;
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetField_InitializedWithIncorrectString_ThrowArgumentException()
        {
            StringFieldProvider provider = new StringFieldProvider(_inputString);
            Assert.Throws<ArgumentException>(() => { IField field = provider.GetField(); });
        }
    }
}
