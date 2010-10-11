using System;
using NUnit.Framework;
using Exts;
using System.Linq;

namespace CSharpClient
{
    [TestFixture]
    public class Client
    {
        [Test]
        public void TestString()
        {
            Assert.That("".IsNullOrWhiteSpace(), Is.True);
        }
    }
}