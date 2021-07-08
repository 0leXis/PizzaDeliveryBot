using System;
using System.Collections.Generic;
using NUnit.Framework;
using PizzaDeliveryBot;

namespace UnitTests
{
    [TestFixture("5x5 (1, 3) (4, 4)", "ENNNDEEEND")]
    [TestFixture("6x7 (5, 5) (3, 4) (1, 5) (0, 2) (3, 1)", "EEEEENNNNNDWWSDWWNDWSSSDEEESD")]
    [TestFixture("4x7 (3, 6) (0, 6) (2, 2) (0, 0) (3, 0)", "EEENNNNNNDWWWDEESSSSDWWSSDEEED")]
    [TestFixture("9x1 (8, 0) (0, 0) (4, 0)", "EEEEEEEEDWWWWWWWWDEEEED")]
    [TestFixture("2x7 (0, 6) (1, 2) (1, 4) (1, 3)", "NNNNNNDESSSSDNNDSD")]
    [TestFixture("4x4 (0, 3) (3, 0) (1, 2) (2, 1)", "NNNDEEESSSDWWNNDESD")]
    [TestFixture("1x5 (0, 4) (0, 0) (0, 2)", "NNNNDSSSSDNND")]
    //Double pizza
    [TestFixture("1x5 (0, 4) (0, 0) (0, 2) (0, 4)", "NNNNDSSSSDNNDNND")]
    //No points
    [TestFixture("5x6", "")]
    public class SimplePathFinderCorrectDataUnitTests
    {
        private string _inputString;
        private IField _inputField;
        private string _outputString;

        public SimplePathFinderCorrectDataUnitTests(string inputString, string outputString)
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
            SimplePathFinder finder = new SimplePathFinder(_inputField);
            Assert.AreEqual(_outputString, finder.CalculatePath());
        }
    }

    public class SimplePathFinderIncorrectDataUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InitializedWithNullField_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentException>(() => { SimplePathFinder finder = new SimplePathFinder(null); });
        }
    }
}
