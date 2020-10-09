
namespace UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PrivateObjects
    {
        public class UnitUnderTest
        {
            private int myPrivateParts = 42;
            public int ThePublicValue { get { return myPrivateParts; } }
        }

        [TestMethod]
        public void TestPrivates()
        {
            var uut = new UnitUnderTest();
            var privateObject = new PrivateObject(uut);
            Assert.AreEqual(42, privateObject.GetField("myPrivateParts"));

            privateObject.SetField("myPrivateParts", 23);
            Assert.AreEqual(23, uut.ThePublicValue);
        }
    }
}
