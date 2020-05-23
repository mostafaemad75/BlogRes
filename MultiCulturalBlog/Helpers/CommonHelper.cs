using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MultiCulturalBlog.Model;
using MultiCulturalBlog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MultiCulturalBlog.Helpers
{
    public class CommonHelper : ICommonHelper
    {
        private readonly AzureStorageConfig _bolbStorageConfig = null;
        public CommonHelper(IOptions<AzureStorageConfig> config)
        {
            _bolbStorageConfig = config.Value;
        }
        public async Task<Attachment> UploadFileAsync(IFormFile file, FileType folderType)
        {
            var attachment = new Attachment();
            Stream fileStream;
            int indexOfFileDot = file.FileName.IndexOf(".");
            string extension = file.FileName.Substring(indexOfFileDot + 1, file.FileName.Length - indexOfFileDot - 1);
            string serverfileName = string.Format("{0}.{1}", DateTime.Now.Ticks.ToString(), extension);
            string originalFileName = file.FileName.Substring(0, indexOfFileDot);
            using (fileStream = file.OpenReadStream())
            {
                var isUploaded = await StorageHelper.UploadFileToStorage(fileStream, serverfileName, _bolbStorageConfig, folderType);
                var folderName = folderType == FileType.File ? _bolbStorageConfig.FileContainer : _bolbStorageConfig.ImageContainer;
                if (isUploaded)
                {
                    attachment.ContentType = file.ContentType;
                    attachment.Extension = extension;
                    attachment.OriginalFileName = originalFileName;
                    attachment.ServerFileName = serverfileName;
                    attachment.FileUrl = $"https://{_bolbStorageConfig.AccountName}.blob.core.windows.net/{folderName}/{serverfileName}";
                }
            }

            fileStream.Dispose();
            return attachment;
        }

        public Attachment[] GetMatchedAttachment(Attachment[] original, Attachment[] modified)
        {
            var newAttachments = new Attachment[modified.Length];
            
            for(int i = 0; i< modified.Length; i++)
            {
                newAttachments[i] = SearchForAttachment(original, modified[i].ServerFileName);
            }
            return newAttachments;
        }

        private Attachment SearchForAttachment(Attachment[] original, string serverFileName)
        {
            for(int i = 0; i < original.Length; i++)
            {
                if(original[i].ServerFileName == serverFileName)
                {
                    return original[i];
                }
            }

            return null;
        }
    }
}
