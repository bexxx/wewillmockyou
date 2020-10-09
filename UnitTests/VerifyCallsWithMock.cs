using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitUnderTest;

namespace UnitTests
{
    [TestClass]
    public class VerifyCallsWithMock
    {
        [TestMethod]
        public async Task DocumentLengthTestAsync()
        {
            // setting up mocks
            var complexFunctionality = new Mock<IDocumentProvider>();
            complexFunctionality.Setup(c => c.FetchDocumentAsync(It.IsAny<Uri>())).ReturnsAsync("Hello world!");
            var simpleFunctionality = new Mock<ISimpleFunctionality>();

            /// uut usage
            var uut = new SimpleUnitUnderTest(complexFunctionality.Object, simpleFunctionality.Object);
            await uut.DoStuffAsync(new Uri("https://moq.com"));
            await uut.DoStuffAsync(new Uri("https://moq.com"));

            complexFunctionality.Verify(c => c.FetchDocumentAsync(new Uri("https://moq.com")), Times.AtMost(3));
            complexFunctionality.Verify(c => c.FetchDocumentAsync(It.IsAny<Uri>()), Times.Exactly(2));
            complexFunctionality.Verify(c => c.FetchDocumentAsync(It.Is<Uri>(u => u.Host.EndsWith("com"))), Times.AtLeastOnce);
        }
    }
}
