using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AsyncLazy;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;


namespace MultiCulturalBlog.Infrastructure.Data
{
    public class CosmosDbClient : ICosmosDbClient
    {
        private readonly string _databaseName;
        private readonly string _collectionName;
        private readonly IDocumentClient _documentClient;
        private readonly AsyncLazy<Database> _database;
        private AsyncLazy<DocumentCollection> _collection;
        public CosmosDbClient(string databaseName, string collectionName, IDocumentClient documentClient)
        {
            _databaseName = databaseName ?? throw new ArgumentNullException(nameof(databaseName));
            _collectionName = collectionName ?? throw new ArgumentNullException(nameof(collectionName));
            _documentClient = documentClient ?? throw new ArgumentNullException(nameof(documentClient));
            _database = new AsyncLazy<Database>(async () => await GetOrCreateDatabaseAsync());
            _collection = new AsyncLazy<DocumentCollection>(async () => await GetOrCreateCollectionAsync());
        }
        private async Task<Database> GetOrCreateDatabaseAsync()
        {
            Database database = _documentClient.CreateDatabaseQuery()
                .Where(db => db.Id == _databaseName).ToArray().FirstOrDefault();
            if (database == null)
            {
                database = await _documentClient.CreateDatabaseAsync(
                    new Database { Id = _databaseName });
            }

            return database;
        }

        private async Task<DocumentCollection> GetOrCreateCollectionAsync()
        {
            DocumentCollection collection = _documentClient.CreateDocumentCollectionQuery((await _database.GetValueAsync()).SelfLink).Where(c => c.Id == _collectionName).ToArray().FirstOrDefault();

            if (collection == null)
            {
                collection = new DocumentCollection { Id = _collectionName };

                collection = await _documentClient.CreateDocumentCollectionAsync((await _database.GetValueAsync()).SelfLink, collection);
            }

            return collection;
        }

        public async Task<Document> ReadDocumentAsync(string documentId)
        {
            var documents = _documentClient.CreateDocumentQuery((await _collection.GetValueAsync()).SelfLink).AsEnumerable();
            return documents.Where(d => d.Id == documentId.ToString()).ToList().FirstOrDefault();           
        }

        public async Task<Document> CreateDocumentAsync(object document, RequestOptions options = null,
            bool disableAutomaticIdGeneration = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _documentClient.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(_databaseName, _collectionName), document, options,
                disableAutomaticIdGeneration, cancellationToken);
        }

        public async Task<Document> ReplaceDocumentAsync(string documentId, object document,
            RequestOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _documentClient.ReplaceDocumentAsync(
                UriFactory.CreateDocumentUri(_databaseName, _collectionName, documentId), document, options,
                cancellationToken);
        }

        public async Task<Document> DeleteDocumentAsync(string documentId, RequestOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _documentClient.DeleteDocumentAsync(
                UriFactory.CreateDocumentUri(_databaseName, _collectionName, documentId), options, cancellationToken);
        }

        public async Task<IEnumerable<T>> ReadAllDocumentAsync<T>(RequestOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return _documentClient.CreateDocumentQuery<T>(
                (await _collection.GetValueAsync()).SelfLink).AsEnumerable();
        }

        public async Task<bool> RemoveAsync(string id, RequestOptions requestOptions = null)
        {
            bool isSuccess = false;

            var doc = await GetDocumentByIdAsync(id);
           
            if (doc != null)
            {
                var result = await _documentClient.DeleteDocumentAsync(doc.SelfLink, requestOptions);

                isSuccess = result.StatusCode == HttpStatusCode.NoContent;
            }

            return isSuccess;
        }
        private async Task<Document> GetDocumentByIdAsync(object id)
        {
            return _documentClient.CreateDocumentQuery<Document>((await _collection.GetValueAsync()).SelfLink).AsEnumerable().Where(d => d.Id == id.ToString()).AsEnumerable().FirstOrDefault();
        }

    }
}
