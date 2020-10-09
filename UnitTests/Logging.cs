
namespace UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LoggingTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Logging()
        {
            this.TestContext.WriteLine("Hello World.");
        }
    }
}
