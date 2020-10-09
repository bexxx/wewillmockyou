
namespace UnitTests
{
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TimeoutTest
    {
        [TestMethod]
        [Timeout(1000)]
        public async Task TimeoutTestAsync()
        {
            await Task.Delay(500);
        }
    }
}
