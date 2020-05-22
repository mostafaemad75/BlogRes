using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiCulturalBlog.Models
{
    public class AzureStorageConfig
    {
        public string AccountName { get; set; }
        public string AccountKey { get; set; }
        public string ImageContainer { get; set; }
        public string FileContainer { get; set; }
        public string ThumbnailContainer { get; set; }
    }
}
