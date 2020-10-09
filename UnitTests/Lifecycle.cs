using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class Lifecycle
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context) { }

        [AssemblyCleanup]
        public static void AssemblyCleanup() { }


        [ClassInitialize]
        public static void ClassInitialize(TestContext context) { }

        [ClassCleanup]
        public static void ClassCleanup() { }

        public Lifecycle() { }

        [TestInitialize]
        public void TestInitialize() { }
    }
}
