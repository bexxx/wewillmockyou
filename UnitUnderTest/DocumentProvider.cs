using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UnitUnderTest
{
    public class DocumentProvider : IDocumentProvider
    {
        private readonly HttpClient httpClient;
        private string cachedDocument;

        public DocumentProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        string IDocumentProvider.CachedDocument => this.cachedDocument;

        async Task<string> IDocumentProvider.FetchDocumentAsync(Uri url)
        {
            var response = await this.httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            this.cachedDocument = await response.Content.ReadAsStringAsync();
            
            return this.cachedDocument;
        }
    }
}
