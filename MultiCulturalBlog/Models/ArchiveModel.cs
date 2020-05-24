using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiCulturalBlog.Models
{
    public class ArchiveModel
    {
        public string Year { get; set; }
        public int Count { get; set; }
        public List<BlogModel> Blogs { get; set; }
    }

    public class BlogModel
    {
        public string Title { get; set; }
        public string Id { get; set; }
    }
}
