using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB_953504_Kozlovski.Data;
using WEB_953504_Kozlovski.Entities;

namespace WEB_953504_Kozlovski.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WEB_953504_Kozlovski.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(WEB_953504_Kozlovski.Data.ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        public IActionResult OnGet()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "BrandName");
            return Page();
        }

        [BindProperty]
        public Notebook Notebook { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Notebooks.Add(Notebook);
            await _context.SaveChangesAsync();

            if (Image != null)
            {
                var fileName = $"{Notebook.NotebookId}" + Path.GetExtension(Image.FileName);
                Notebook.Image = fileName;

                var path = Path.Combine(_environment.WebRootPath, "Images", fileName);

                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
