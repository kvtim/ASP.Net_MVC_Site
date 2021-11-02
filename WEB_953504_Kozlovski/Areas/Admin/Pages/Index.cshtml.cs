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
    public class IndexModel : PageModel
    {
        private readonly WEB_953504_Kozlovski.Data.ApplicationDbContext _context;

        public IndexModel(WEB_953504_Kozlovski.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Notebook> Notebook { get;set; }

        public async Task OnGetAsync()
        {
            Notebook = await _context.Notebooks
                .Include(n => n.Brand).ToListAsync();
        }
    }
}
