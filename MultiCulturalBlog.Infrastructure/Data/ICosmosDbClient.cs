using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace MultiCulturalBlog.Infrastructure.Data
{
    public interface ICosmosDbClient
    {
        Task<Document> ReadDocumentAsync(string documentId);

        Task<Document> CreateDocumentAsync(object document, RequestOptions options = null,
            bool disableAutomaticIdGeneration = false,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<Document> ReplaceDocumentAsync(string documentId, object document, RequestOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<Document> DeleteDocumentAsync(string documentId, RequestOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<T>> ReadAllDocumentAsync<T>(RequestOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> RemoveAsync(string id, RequestOptions requestOptions = null);
    }
}