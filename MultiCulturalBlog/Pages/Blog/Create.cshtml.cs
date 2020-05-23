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
        private readonly ICommonHelper _commandHelper;
        private readonly IBlogRepository _context;

        public CreateModel(IBlogRepository context, ICommonHelper commandHelper)
        {
            _context = context;
            _commandHelper = commandHelper;
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
            if (PicturFile.Length > 0)
            {
                if (StorageHelper.IsImage(PicturFile))
                {
                    var uploadedPic = await _commandHelper.UploadFileAsync(PicturFile, FileType.Image);
                    Blog.PhotoUrl = uploadedPic.FileUrl;
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
                        Blog.Attachments[i] = await _commandHelper.UploadFileAsync(Attachments[i], FileType.File);
                    }
                }
            }
            Blog.CreationDate = DateTime.Now;
            await _context.AddAsync(Blog);
            return RedirectToPage("./Index");
        }
    }
}