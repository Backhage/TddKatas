using NUnit.Framework;
using static Greeting.Greeting;

namespace GreetingTest
{
    [TestFixture]
    [Category("Unit")]
    public class GreetingTests
    {
        [Test]
        public void TestGreet()
        {
            Assert.AreEqual("Hello, Bob.", Greet("Bob"));
        }

        [Test]
        public void TestNull()
        {
            Assert.AreEqual("Hello, my friend.", Greet(null));
        }

        [Test]
        public void TestShouting()
        {
            Assert.AreEqual("HELLO JERRY!", Greet("JERRY"));
        }

        [Test]
        public void TestMultipleNames()
        {
            Assert.AreEqual("Hello, Jill and Jane.", Greet("Jill", "Jane"));
            Assert.AreEqual("Hello, Amy, Brian, and Charlotte.", Greet("Amy", "Brian", "Charlotte"));
        }

        [Test]
        public void TestNormalAndShouting()
        {
            Assert.AreEqual("Hello, Jill. AND HELLO ANDREW!", Greet("Jill", "ANDREW"));
            Assert.AreEqual("Hello, Jill and Jane. AND HELLO JACK AND JOE!", Greet("Jill", "Jane", "JACK", "JOE"));
            Assert.AreEqual("Hello, Judy, Jane, and Jill. AND HELLO JIM, JACK, AND JOE!", Greet("Judy", "Jane", "JIM", "Jill", "JACK", "JOE"));
        }
    }
}
