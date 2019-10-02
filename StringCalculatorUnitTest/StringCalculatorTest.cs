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
            var input = "1,2,3,4,5,6,7,8,9,10,11,12";
            var expected = 78;
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
            var expected = 2010;
            var stringCalculator = new StringCalculator.StringCalculator(input);

            // Act
            var actual = stringCalculator.CalculateSum();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOneInput()
        {
            // Arrange
            string input = "5";
            var expected = 5;
            var stringCalculator = new StringCalculator.StringCalculator(input);

            // Act
            var actual = stringCalculator.CalculateSum();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
