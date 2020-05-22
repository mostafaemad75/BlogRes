using System;
using System.Collections.Generic;
using System.Text;

namespace MultiCulturalBlog.Model
{
    public class Attachment : Entity
    {
        public string OriginalFileName { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public string ServerFileName { get; set; }
        public string FileUrl { get; set; }
    }
}
