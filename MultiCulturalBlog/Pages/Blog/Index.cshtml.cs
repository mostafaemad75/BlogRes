using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class IndexModel : PageModel
    {

        private readonly IBlogRepository _context;
        private readonly ICommonHelper _commandHelper;
        public IndexModel(IBlogRepository context, ICommonHelper commandHelper)
        {
            _context = context;
            _commandHelper = commandHelper;
        }

        [BindProperty(SupportsGet = true)]
        public string Year { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Month { get; set; }
        public List<Blog> LatestBlogs { get; set; }
        public List<ArchiveModel> ArchiveModels { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var allBlogs = (await _context.GetAllAsync());
            LatestBlogs = _commandHelper.BlogArchiveSearch(allBlogs, Year, Month);
            ArchiveModels = _commandHelper.GenerateBlogArchiveModel(allBlogs);
            return Page();
        }
    }
}