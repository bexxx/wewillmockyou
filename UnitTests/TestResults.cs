using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    class TestResults
    {
        [TestMethod]
        public void TestFails()
        {
            Assert.Fail("Test failed swiftly");
        }

        [TestMethod]
        public void TestFailsMaybe()
        {
            Assert.Inconclusive("Test could not figure it out");
        }
    }
}
