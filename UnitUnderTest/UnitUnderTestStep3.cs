namespace UnitUnderTest
{
    using System;
    using System.Threading.Tasks;

    public class UnitUnderTestStepThree
    {
        private readonly IDocumentProvider documentProvider;

        public UnitUnderTestStepThree(IDocumentProvider documentProvider)
        {
            this.documentProvider = documentProvider;
        }

        public async Task<int> GetDocumentLength(Uri url) {
            Console.WriteLine(url.ToString());
            var document = await this.documentProvider.FetchDocumentAsync(url);
            return document.Length;
        }
    }
}
