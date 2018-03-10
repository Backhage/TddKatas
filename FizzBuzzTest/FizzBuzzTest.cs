using static FizzBuzz.FizzBuzz;
using NUnit.Framework;

namespace FizzBuzzTest
{
    [TestFixture]
    [Category("Unit")]
    public class FizzBuzzTest
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual("1", Eval(1));
        }

        [Test]
        public void TestThree()
        {
            Assert.AreEqual("Fizz", Eval(3));
        }

        [Test]
        public void TestFive()
        {
            Assert.AreEqual("Buzz", Eval(5));
        }
        
        [Test]
        public void TestFifteen()
        {
            Assert.AreEqual("FizzBuzz", Eval(15));
        }
    }
}
