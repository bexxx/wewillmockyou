namespace UnitUnderTest
{
    using System;
    using System.Threading.Tasks;

    public class SimpleUnitUnderTest
    {
        private readonly IDocumentProvider complexFunctionality;
        private readonly ISimpleFunctionality simpleFunctionality;

        public SimpleUnitUnderTest(
            IDocumentProvider complexFunctionality,
            ISimpleFunctionality simpleFunctionality)
        {
            this.complexFunctionality = complexFunctionality;
            this.simpleFunctionality = simpleFunctionality;
        }

        public int DoSimpleStuff()
        {
            return this.simpleFunctionality.GetSimpleLength();
        }

        public async Task<int> DoStuffAsync(Uri url)
        {
            Console.WriteLine(url.ToString());
            var document = await this.complexFunctionality.FetchDocumentAsync(url);
            return document.Length;
        }
    }
}
