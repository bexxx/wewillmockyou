using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitUnderTest;

namespace UnitTests
{
    [TestClass]
    public class AutoMocking
    {
        [TestMethod]
        public async Task DocumentLengthTestAsync()
        {
            var url = new Uri("https://test.com");
            var response = "hello world!";
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });
            var complex = fixture
                .Freeze<Mock<IDocumentProvider>>();
            complex
                .Setup(x => x.FetchDocumentAsync(It.IsAny<Uri>()))
                .ReturnsAsync(response);

            var uut = fixture.Create<SimpleUnitUnderTest>();
            var actual = await uut.DoStuffAsync(url);

            Assert.AreEqual(response.Length, actual);

            complex.Verify(c => c.FetchDocumentAsync(url), Times.Once);
        }
    }
}
