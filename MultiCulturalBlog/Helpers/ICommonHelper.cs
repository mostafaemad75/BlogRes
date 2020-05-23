using Microsoft.AspNetCore.Http;
using MultiCulturalBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiCulturalBlog.Helpers
{
    public interface ICommonHelper
    {
        Task<Attachment> UploadFileAsync(IFormFile file, FileType folderType);
        Attachment[] GetMatchedAttachment(Attachment[] original, Attachment[] modified);
    }
}
