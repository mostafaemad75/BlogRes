using MultiCulturalBlog.Model;
using System;
using Microsoft.Azure.Documents;
using MultiCulturalBlog.Model.Interfaces;

namespace MultiCulturalBlog.Infrastructure.Data
{
    public class BlogRepository : CosmosDbRepository<Blog>, IBlogRepository
    {
        public BlogRepository(ICosmosDbClientFactory factory) : base(factory) { }

        public override string CollectionName { get; } = "blogrescontainer";
        public override string GenerateId(Blog entity) => $"{Guid.NewGuid()}";
        public override PartitionKey ResolvePartitionKey(string entityId) => new PartitionKey(entityId.Split(':')[0]);
    }
}
