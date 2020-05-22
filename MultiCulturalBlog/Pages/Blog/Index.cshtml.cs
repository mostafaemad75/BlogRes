using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MultiCulturalBlog.Model;
using MultiCulturalBlog.Model.Interfaces;

namespace MultiCulturalBlog
{
    public class IndexModel : PageModel
    {

        private readonly IBlogRepository _context;

        public IndexModel(IBlogRepository context)
        {
            _context = context;
        }
        
        public List<Blog> LatestBlogs { get; set; }
        public async Task<IActionResult> OnGet()
        {
            LatestBlogs = (await _context.GetAllAsync()).ToList();
            return Page();
        }
    }
}