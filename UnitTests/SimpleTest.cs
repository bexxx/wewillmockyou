
namespace UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TraitsTest
    {
        [TestMethod]
        public void TestStringLength()
        {
            var uut = "hello world!";
            Assert.AreEqual(12, uut.Length, "string has unexpected length");
            Assert.IsTrue(uut.Length > 0, "string has unexpected length");
            Assert.IsNotNull(uut);
            Assert.AreSame("hello" + " world!", uut);
            Assert.IsInstanceOfType(uut, typeof(string));
            Assert.ThrowsException<ArgumentNullException>(() => uut.Contains((string)null));
        }
    }
}
