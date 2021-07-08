using System;
using System.Collections.Generic;
using NUnit.Framework;
using PizzaDeliveryBot;

namespace UnitTests
{
    [TestFixture("5x5 (1, 3) (4, 4)", "ENNNDEEEND")]
    [TestFixture("6x7 (5, 5) (3, 4) (1, 5) (0, 2) (3, 1)", "NNDENNNDEESDEENDWWSSSSD")]
    [TestFixture("4x7 (3, 6) (0, 6) (2, 2) (0, 0) (3, 0)", "DEEEDWNNDENNNNDWWWD")]
    [TestFixture("9x1 (8, 0) (0, 0) (4, 0)", "DEEEEDEEEED")]
    [TestFixture("2x7 (0, 6) (1, 2) (1, 4) (1, 3)", "ENNDNDNDWNND")]
    [TestFixture("4x4 (0, 3) (3, 0) (1, 2) (2, 1)", "NNNDESDESDESD")]
    [TestFixture("1x5 (0, 4) (0, 0) (0, 2)", "DNNDNND")]
    //Double pizza
    [TestFixture("1x5 (0, 4) (0, 0) (0, 2) (0, 4)", "DNNDNNDD")]
    //No points
    [TestFixture("5x6", "")]
    public class OptimalPathFinderCorrectDataUnitTests
    {
        private string _inputString;
        private IField _inputField;
        private string _outputString;

        public OptimalPathFinderCorrectDataUnitTests(string inputString, string outputString)
        {
            _inputString = inputString;
            _outputString = outputString;
        }

        [SetUp]
        public void Setup()
        {
            _inputField = new StringFieldProvider(_inputString).GetField();
        }

        [Test]
        public void CalculatePath_InitializedWithCorrectData_ReturnCorrectData()
        {
            OptimalPathFinder finder = new OptimalPathFinder(_inputField);
            Assert.AreEqual(_outputString, finder.CalculatePath());
        }
    }

    public class OptimalPathFinderIncorrectDataUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InitializedWithNullField_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentException>(() => { OptimalPathFinder finder = new OptimalPathFinder(null); });
        }
    }
}
