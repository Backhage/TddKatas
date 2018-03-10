using NUnit.Framework;
using StringCalculator;
using System;

namespace StringCalculatorTest
{
    [TestFixture]
    [Category("Unit")]
    public class CalculationTests
    {
        public void TestAdd()
        {
            Assert.AreEqual(0, Calculator.Add(""));
            Assert.AreEqual(1, Calculator.Add("1"));
            Assert.AreEqual(10, Calculator.Add("1,2,3,4"));
        }

        [Test]
        public void TestDifferentDelimiters()
        {
            Assert.AreEqual(6, Calculator.Add("1\n2,3"));
        }

        [Test]
        public void TestChangingDelimiter()
        {
            Assert.AreEqual(7, Calculator.Add("//;\n3;4"));
        }

        [Test]
        public void TestNegative()
        {
            Assert.Throws<ArgumentException>(() => Calculator.Add("-1"));
            Assert.Throws<ArgumentException>(() => Calculator.Add("1,-1"));
        }

        [Test]
        public void TestTooLarge()
        {
            Assert.AreEqual(2, Calculator.Add("1001,2"));
        }

        [Test]
        public void TestMulticharDelimiter()
        {
            Assert.AreEqual(6, Calculator.Add("//[***]\n4***2"));
        }

        [Test]
        public void TestMultipleDelimiters()
        {
            Assert.AreEqual(6, Calculator.Add("//[*][%]\n1*2%3"));
            Assert.AreEqual(10, Calculator.Add("//[**][%%%]\n1**2%%%3**4"));
        }
    }
}
