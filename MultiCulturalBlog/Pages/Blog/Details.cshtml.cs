using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MultiCulturalBlog.Model;
using MultiCulturalBlog.Model.Interfaces;

namespace MultiCulturalBlog
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogRepository _context;

        public DetailsModel(IBlogRepository context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public Blog Blog { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Blog = await _context.GetByIdAsync(Id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _context.RemoveAsync(Id);
            return RedirectToPage("./Index");
        }
    }
}