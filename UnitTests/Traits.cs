
namespace UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SimpleTest
    {
        [TestMethod]
        [TestCategory("UnitTest")]
        [TestProperty("Component", nameof(String))]
        [TestProperty("SubComponent", nameof(string.Length))]
        public void TestStringLength()
        {
            var uut = "hello world!";
            Assert.AreEqual(12, uut.Length, "string has unexpected length");
        }
    }
}
