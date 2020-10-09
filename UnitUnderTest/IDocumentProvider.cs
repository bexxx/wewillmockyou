namespace UnitUnderTest
{
    using System;
    using System.Threading.Tasks;

    public interface IDocumentProvider
    {
        Task<string> FetchDocumentAsync(Uri url);

        string CachedDocument { get; }
    }
}
