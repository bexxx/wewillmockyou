namespace UnitUnderTest
{
    using System;
    using System.Threading.Tasks;
    using Autofac.Features.AttributeFilters;

    public class ComplexUnitUnderTest
    {
        private readonly IDocumentProvider complexFunctionality1;
        private readonly IDocumentProvider complexFunctionality2;

        public ComplexUnitUnderTest(
            [KeyFilter("Key1")] IDocumentProvider complexFunctionality1,
            [KeyFilter("Key2")] IDocumentProvider complexFunctionality2)
        {
            this.complexFunctionality1 = complexFunctionality1;
            this.complexFunctionality2 = complexFunctionality2;
        }

        public async Task<int> DoStuffAsync(Uri url)
        {
            Console.WriteLine(url.ToString());
            var document1 = await this.complexFunctionality1.FetchDocumentAsync(url);
            var document2 = await this.complexFunctionality2.FetchDocumentAsync(url);

            return document1.Length + document2.Length;
        }
    }
}
