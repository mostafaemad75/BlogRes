using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using MultiCulturalBlog.Helpers;
using MultiCulturalBlog.Model;
using MultiCulturalBlog.Model.Interfaces;
using MultiCulturalBlog.Models;

namespace MultiCulturalBlog
{
    public class CreateModel : PageModel
    {
        private readonly AzureStorageConfig _bolbStorageConfig = null;
        private readonly IBlogRepository _context;

        public CreateModel(IBlogRepository context, IOptions<AzureStorageConfig> config)
        {
            _context = context;
            _bolbStorageConfig = config.Value;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Blog Blog { get; set; }
        [BindProperty]
        public IFormFile PicturFile { get; set; }

        public List<IFormFile> Attachments { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            int indexOfFileDot = 0;
            var serverfileName = "";
            var originalFileName = "";
            var extension = "";
            Stream fileStream;
            if (PicturFile.Length > 0)
            {
                if (StorageHelper.IsImage(PicturFile))
                {
                    indexOfFileDot = PicturFile.FileName.IndexOf(".");
                    extension = PicturFile.FileName.Substring(indexOfFileDot + 1, PicturFile.FileName.Length - indexOfFileDot - 1);
                    serverfileName = string.Format("{0}.{1}", DateTime.Now.Ticks.ToString(), extension);
                    originalFileName = PicturFile.FileName.Substring(0, indexOfFileDot);
                    using (fileStream = PicturFile.OpenReadStream())
                    {
                        var isUploaded = await StorageHelper.UploadFileToStorage(fileStream, serverfileName, _bolbStorageConfig, FileType.Image);
                        if (isUploaded)
                        {
                            Blog.PhotoUrl = $"https://{_bolbStorageConfig.AccountName}.blob.core.windows.net/{_bolbStorageConfig.ImageContainer}/{serverfileName}";
                        }
                    }
                   
                    fileStream.Dispose();
                }
                else
                {
                    ModelState.AddModelError("PhotoUrl", "Please select image type file");
                    return Page();
                }
            }
            if (Request.Form.Files.Count > 0)
            {
                Attachments = Request.Form.Files.Where(x => x.Name.Contains("Attachments")).ToList();
                if (Attachments.Count > 0)
                {
                    Blog.Attachments = new Attachment[Attachments.Count];

                    for (var i = 0; i < Attachments.Count; i++)
                    {
                        indexOfFileDot = Attachments[i].FileName.IndexOf(".");

                        serverfileName = Attachments[i].FileName.Substring(0, indexOfFileDot) + "_" + DateTime.Now.Ticks.ToString();

                        originalFileName = Attachments[i].FileName.Substring(0, indexOfFileDot);

                        extension = Attachments[i].FileName.Substring(indexOfFileDot + 1, Attachments[i].FileName.Length - indexOfFileDot - 1);

                        Blog.Attachments[i] = new Attachment()
                        {
                            ContentType = Attachments[i].ContentType,
                            Extension = extension,
                            OriginalFileName = originalFileName,
                            ServerFileName = serverfileName,
                            FileUrl = $"https://{_bolbStorageConfig.AccountName}.blob.core.windows.net/{_bolbStorageConfig.FileContainer}/{serverfileName}.{extension}"
                        };
                        using (fileStream = Attachments[i].OpenReadStream())
                        {
                            await StorageHelper.UploadFileToStorage(fileStream, $"{serverfileName}.{extension}", _bolbStorageConfig, FileType.File);
                        }
                       
                        fileStream.Dispose();
                    }
                }
            }
            var toDo = await _context.AddAsync(Blog);


            return RedirectToPage("./Index");
        }
    }
}