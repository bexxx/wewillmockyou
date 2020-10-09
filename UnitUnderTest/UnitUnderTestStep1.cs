namespace UnitUnderTest
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class UnitUnderTestStepOne
    {
        public async Task<int> GetDocumentLength(Uri url)
        {
            Console.WriteLine(url.ToString());
            var document = await DocumentProvider.SomethingVerySlowAsync(url);
            return document.Length;
        }

        public static class DocumentProvider
        {
            public static async Task<string> SomethingVerySlowAsync(Uri url)
            {
                var response = await new HttpClient().GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
