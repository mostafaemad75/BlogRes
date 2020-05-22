using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MultiCulturalBlog.Model
{
    public class Blog : Entity
    {

        [Required(ErrorMessage = "Please type blog title")]
        public string Title { get; set; }
        public string Body { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime CreationDate { get; set; }
        public string[] VideoUrls { get; set; }
        public Attachment[] Attachments { get; set; }
    }
}
