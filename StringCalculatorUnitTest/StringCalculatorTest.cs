using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculatorUnitTest
{
    [TestClass]
    public class StringCalculatorTest
    {
        [TestMethod]
        public void TestHappyPath()
        {
            // Arrange
            var input = "40,50";
            var expected = 90;
            var stringCalculator = new StringCalculator.StringCalculator(input);

            // Act
            var actual = stringCalculator.CalculateSum();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNull()
        {
            // Arrange
            string input = null;
            var expected = 0;
            var stringCalculator = new StringCalculator.StringCalculator(input);

            // Act
            var actual = stringCalculator.CalculateSum();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWhitespaces()
        {
            // Arrange
            string input = "20     ,   40   ";
            var expected = 60;
            var stringCalculator = new StringCalculator.StringCalculator(input);

            // Act
            var actual = stringCalculator.CalculateSum();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCharacters()
        {
            // Arrange
            string input = "5,tytyt";
            var expected = 5;
            var stringCalculator = new StringCalculator.StringCalculator(input);

            // Act
            var actual = stringCalculator.CalculateSum();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMoreThanTwoInputs()
        {
            // Arrange
            string input = "5,5,1000,1000";
            var expected = 10;
            var stringCalculator = new StringCalculator.StringCalculator(input);

            // Act
            var actual = stringCalculator.CalculateSum();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
