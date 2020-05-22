using Microsoft.Azure.Documents;
using MultiCulturalBlog.Model;

namespace MultiCulturalBlog.Infrastructure.Data
{
    public interface IDocumentCollectionContext<in T> where T : Entity
    {
        string CollectionName { get; }

        string GenerateId(T entity);

        PartitionKey ResolvePartitionKey(string entityId);
    }
}
