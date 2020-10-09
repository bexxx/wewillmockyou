namespace UnitTests
{
    using System;
    using System.Threading.Tasks;
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RichardSzalay.MockHttp;
    using UnitUnderTest;
    
    [TestClass]
    public class HttpMockTest
    {
        [TestMethod]
        public async Task TestWithHttpMock()
        {
            var url = new Uri("https://test.com");

            var mockHttp = new MockHttpMessageHandler();
            var body = "<html></html>";
            mockHttp.When(url.ToString())
                    .Respond("text/html", body);

            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });
            fixture.Inject(mockHttp.ToHttpClient());

            IDocumentProvider uut = fixture.Create<DocumentProvider>();

            var document = await uut.FetchDocumentAsync(url);
            Assert.AreEqual(body.Length, document.Length);

            mockHttp.VerifyNoOutstandingRequest();
        }
    }
}
