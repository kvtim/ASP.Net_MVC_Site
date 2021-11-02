using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_953504_Kozlovski.Data;
using WEB_953504_Kozlovski.Entities;

namespace WEB_953504_Kozlovski.Areas.Admin.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly WEB_953504_Kozlovski.Data.ApplicationDbContext _context;

        public DeleteModel(WEB_953504_Kozlovski.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Notebook Notebook { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Notebook = await _context.Notebooks
                .Include(n => n.Brand).FirstOrDefaultAsync(m => m.NotebookId == id);

            if (Notebook == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Notebook = await _context.Notebooks.FindAsync(id);

            if (Notebook != null)
            {
                _context.Notebooks.Remove(Notebook);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
