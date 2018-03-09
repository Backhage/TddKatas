using NUnit.Framework;
using StringCalculator;
using System;

namespace StringCalculatorTest
{
    [TestFixture]
    public class CalculationTests
    {
        public void TestAdd()
        {
            Assert.AreEqual(0, Calculator.Add(""));
            Assert.AreEqual(1, Calculator.Add("1"));
            Assert.AreEqual(10, Calculator.Add("1,2,3,4"));
        }

        [Test]
        public void TestDifferentSeparators()
        {
            Assert.AreEqual(6, Calculator.Add("1\n2,3"));
        }

        [Test]
        public void TestChangingSeparator()
        {
            Assert.AreEqual(7, Calculator.Add("//;\n3;4"));
        }

        [Test]
        public void TestNegative()
        {
            Assert.Throws<ArgumentException>(() => Calculator.Add("-1"));
            Assert.Throws<ArgumentException>(() => Calculator.Add("1,-1"));
        }
    }
}
