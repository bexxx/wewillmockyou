
namespace UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConfigValueTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void ConfigValueTest()
        {
            Assert.IsNotNull(TestContext.Properties["Key"]);
        }
    }
}
