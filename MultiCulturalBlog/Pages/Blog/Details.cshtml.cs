using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MultiCulturalBlog.Helpers;
using MultiCulturalBlog.Model;
using MultiCulturalBlog.Model.Interfaces;
using MultiCulturalBlog.Models;

namespace MultiCulturalBlog
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogRepository _context;
        private readonly ICommonHelper _commandHelper;

        public DetailsModel(IBlogRepository context, ICommonHelper commandHelper)
        {
            _context = context;
            _commandHelper = commandHelper;
        }
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public Blog Blog { get; set; }
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
            await _context.RemoveAsync(Id);
            return RedirectToPage("./Index");
        }
    }
}