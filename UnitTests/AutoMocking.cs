namespace UnitTests
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using UnitUnderTest;
    
    [TestClass]
    public class ManualMocking
    {
        [TestMethod]
        public async Task DocumentLengthTestAsync()
        {
            var complexFunctionality = new Mock<IDocumentProvider>();
            var simpleFunctionality = new Mock<ISimpleFunctionality>();
            var response = "hello world!";
            complexFunctionality
                .Setup(c => c.FetchDocumentAsync(new Uri("https://moq.com")))
                .ReturnsAsync(response);
            complexFunctionality
                .Setup(c => c.FetchDocumentAsync(It.IsAny<Uri>()))
                .ReturnsAsync(response);
            complexFunctionality
                .Setup(c => c.FetchDocumentAsync(It.IsAny<Uri>()))
                .Throws(new NotImplementedException());

            complexFunctionality
                .SetupGet(c => c.CachedDocument)
                .Returns(response);

            complexFunctionality
                .SetupSequence(c => c.FetchDocumentAsync(It.IsAny<Uri>()))
                .ReturnsAsync(response)
                .ReturnsAsync(string.Empty)
                .ReturnsAsync(response);

            complexFunctionality.Setup(c => c.FetchDocumentAsync(It.IsAny<Uri>()))
                .Callback((Uri u) => Console.WriteLine($"Before call to {u}"))
                .ReturnsAsync(response)
                .Callback((Uri u) => Console.WriteLine($"After call to {u}"));

            var uut = new SimpleUnitUnderTest(complexFunctionality.Object, simpleFunctionality.Object);
            var actual = await uut.DoStuffAsync(new Uri("https://test.com"));

            Assert.AreEqual(response.Length, actual);

            var mock = new Mock<IDocumentProvider>(MockBehavior.Strict);
            mock = new Mock<IDocumentProvider>(MockBehavior.Loose);
            mock = new Mock<IDocumentProvider> { DefaultValue = DefaultValue.Mock };

        }
    }
}
