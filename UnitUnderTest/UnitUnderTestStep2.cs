namespace UnitUnderTest
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class UnitUnderTestStepTwo {
        public async Task<int> GetDocumentLength(IDocumentProvider documentProvider, Uri url) {
            Console.WriteLine(url.ToString());
            var document = await documentProvider.SomethingVerySlowAsync(url);
            return document.Length;
        }

        public interface IDocumentProvider {
            Task<string> SomethingVerySlowAsync(Uri url);
        }

        public class DocumentProvider : IDocumentProvider {
            public async Task<string> SomethingVerySlowAsync(Uri url) {
                var response = await new HttpClient().GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
