﻿namespace MultiCulturalBlog.Infrastructure.Data
{
    public interface ICosmosDbClientFactory
    {
        ICosmosDbClient GetClient(string collectionName);
    }
}