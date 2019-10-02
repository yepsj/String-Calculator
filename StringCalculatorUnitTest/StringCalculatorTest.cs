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

        [TestMethod]
        public void TestTwoDelimiters()
        {
            // Arrange
            string input = "1\n2,3";
            var expected = 6;
            var stringCalculator = new StringCalculator.StringCalculator(input);

            // Act
            var actual = stringCalculator.CalculateSum();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSingleDelimiterWithEmptyEntry()
        {
            // Arrange
            string input = "1\n2,";
            var expected = 3;
            var stringCalculator = new StringCalculator.StringCalculator(input);

            // Act
            var actual = stringCalculator.CalculateSum();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNegativeNumbers()
        {
            // Arrange
            string input = "-50,100,-100,200";
            var expectedExceptionMessage = "Unable to process negative numbers: -50, -100";
            var stringCalculator = new StringCalculator.StringCalculator(input);

            // Act
            try
            {
                var actual = stringCalculator.CalculateSum();
                // Fail if no exception thrown
                Assert.Fail();
            }
            // Assert
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(ex.Message.Contains(expectedExceptionMessage));
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
