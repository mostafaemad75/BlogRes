using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MultiCulturalBlog.Helpers;
using MultiCulturalBlog.Model;
using MultiCulturalBlog.Model.Interfaces;
using MultiCulturalBlog.Models;

namespace MultiCulturalBlog
{
    public class UpdateModel : PageModel
    {
        private readonly IBlogRepository _context;
        private readonly ICommonHelper _commandHelper;
        public UpdateModel(IBlogRepository context, ICommonHelper commandHelper)
        {
            _context = context;
            _commandHelper = commandHelper;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public Blog Blog { get; set; }
        [BindProperty]
        public Blog Entity { get; set; }
        [BindProperty]
        public IFormFile PicturFile { get; set; }

        public List<IFormFile> Attachments { get; set; }
        public List<ArchiveModel> ArchiveModels { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var allBlogs = (await _context.GetAllAsync());
            Blog = allBlogs.Where(x => x.Id == Id).FirstOrDefault();
            ArchiveModels = _commandHelper.GenerateBlogArchiveModel(allBlogs);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Blog = await _context.GetByIdAsync(Id);
            Entity.PhotoUrl = Blog.PhotoUrl;
            if (PicturFile != null && PicturFile.Length > 0)
            {
                if (StorageHelper.IsImage(PicturFile))
                {
                    var uploadedPic = await _commandHelper.UploadFileAsync(PicturFile, FileType.Image);
                    Entity.PhotoUrl = uploadedPic.FileUrl;
                }
                else
                {
                    ModelState.AddModelError("PhotoUrl", "Please select image type file");
                    return Page();
                }
            }
            Attachment[] newAttachments;
            var attachmentLength = Entity.Attachments == null ? 0 : Entity.Attachments.Length;
            if (Request.Form.Files.Count > 0)
            {
                Attachments = Request.Form.Files.Where(x => x.Name.Contains("Attachments")).ToList();
                if (Attachments.Count > 0)
                {
                    newAttachments = new Attachment[attachmentLength + Attachments.Count];
                    for (var i = 0; i < Attachments.Count; i++)
                    {
                        newAttachments[i] = await _commandHelper.UploadFileAsync(Attachments[i],FileType.File);
                    }
                }
                else
                {
                    newAttachments = new Attachment[attachmentLength];
                }
            }
            else
            {
                newAttachments = new Attachment[attachmentLength];
            }

            var matchedAttachment = _commandHelper.GetMatchedAttachment(Blog.Attachments, Entity.Attachments);
            int index = 0;
            if(matchedAttachment != null)
            {
                for (int i = Attachments.Count; i < newAttachments.Length; i++)
                {
                    newAttachments[i] = matchedAttachment[index];
                    index++;
                }
            }
          
            Entity.Attachments = newAttachments;
            await _context.UpdateAsync(Entity);
            return RedirectToPage("/Blog/Details", new { Id = Id });
        }
    }
}