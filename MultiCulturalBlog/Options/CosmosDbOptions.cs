﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiCulturalBlog.Options
{
    public class CosmosDbOptions
    {
        public string DatabaseName { get; set; }
        public List<CollectionInfo> CollectionNames { get; set; }

        public void Deconstruct(out string databaseName, out List<CollectionInfo> collectionNames)
        {
            databaseName = DatabaseName;
            collectionNames = CollectionNames;
        }
    }

    public class CollectionInfo
    {
        public string Name { get; set; }
        public string PartitionKey { get; set; }
    }
}
