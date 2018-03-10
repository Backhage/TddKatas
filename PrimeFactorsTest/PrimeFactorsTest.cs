using NUnit.Framework;
using System.Collections.Generic;
using static PrimeFactors.PrimeFactors;

namespace PrimeFactorsTest
{
    [TestFixture]
    [Category("Unit")]
    public class PrimeFactorsTest
    {
        private List<int> List(params int[] ints)
        {
            var list = new List<int>();
            list.AddRange(ints);
            return list;
        }

        [Test]
        public void TestOne()
        {
            Assert.AreEqual(List(), Generate(1));
        }

        [Test]
        public void TestTwo()
        {
            Assert.AreEqual(List(2), Generate(2));
        }

        [Test]
        public void TestThree()
        {
            Assert.AreEqual(List(3), Generate(3));
        }

        [Test]
        public void TestFour()
        {
            Assert.AreEqual(List(2,2), Generate(4));
        }

        [Test]
        public void TestSix()
        {
            Assert.AreEqual(List(2,3), Generate(6));
        }

        [Test]
        public void TestEight()
        {
            Assert.AreEqual(List(2,2,2), Generate(8));
        }

        [Test]
        public void TestNine()
        {
            Assert.AreEqual(List(3,3), Generate(9));
        }
    }
}
