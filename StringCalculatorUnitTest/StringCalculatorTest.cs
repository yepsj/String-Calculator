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
        public void TestExceptionForNegativeNumbers()
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

        [TestMethod]
        public void TestLargeNumbers()
        {
            // Arrange
            string input = "1\n2000, 123456789,80,";
            var expected = 81;
            var stringCalculator = new StringCalculator.StringCalculator(input);

            // Act
            var actual = stringCalculator.CalculateSum();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSingleCharacterDelimiter()
        {
            // Arrange
            string input = "//;\n2;5";
            var expected = 7;
            var stringCalculator = new StringCalculator.StringCalculator(input);

            // Act
            var actual = stringCalculator.CalculateSum();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestStarsMultipleCharacterDelimiter()
        {
            // Arrange
            string input = "//[***]\n11***22***33";
            var expected = 66;
            var stringCalculator = new StringCalculator.StringCalculator(input);

            // Act
            var actual = stringCalculator.CalculateSum();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestParenthesisMultipleCharacterDelimiter()
        {
            // Arrange
            string input = "//[((]\n11((22((33";
            var expected = 66;
            var stringCalculator = new StringCalculator.StringCalculator(input);

            // Act
            var actual = stringCalculator.CalculateSum();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMultipleDelimiters()
        {
            // Arrange
            string input = "//[**][((]\n11((22**33";
            var expected = 66;
            var stringCalculator = new StringCalculator.StringCalculator(input);

            // Act
            var actual = stringCalculator.CalculateSum();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMultipleDelimitersWithLargeNumber()
        {
            // Arrange
            string input = "//[**][((]\n11((22**33**500000**10";
            var expected = 76;
            var stringCalculator = new StringCalculator.StringCalculator(input);

            // Act
            var actual = stringCalculator.CalculateSum();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMultipleDelimitersWithCharacters()
        {
            // Arrange
            string input = "//[*][!!][r9r]\n11r9r22*33!!44";
            var expected = 110;
            var stringCalculator = new StringCalculator.StringCalculator(input);

            // Act
            var actual = stringCalculator.CalculateSum();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
