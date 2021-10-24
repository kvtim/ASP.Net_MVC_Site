using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953504_Kozlovski.Data;
using WEB_953504_Kozlovski.Entities;
using WEB_953504_Kozlovski.Extentions;
using WEB_953504_Kozlovski.Models;

namespace WEB_953504_Kozlovski.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;

        int _pageSize;

        public ProductController(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo)
        {
            var notebooksFiltered = _context.Notebooks.Where(d => !group.HasValue || d.BrandId == group.Value);

            // Put a list of brands in ViewData
            ViewData["Brands"] = _context.Brands;

            // Get the id of the current brand and put it in TempData
            ViewData["CurrentBrand"] = group ?? 0;

            var model = ListViewModel<Notebook>.GetModel(notebooksFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }
    }
}
