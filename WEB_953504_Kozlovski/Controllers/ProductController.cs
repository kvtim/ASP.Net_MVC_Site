using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953504_Kozlovski.Entities;
using WEB_953504_Kozlovski.Models;

namespace WEB_953504_Kozlovski.Controllers
{
    public class ProductController : Controller
    {
        List<Notebook> _notebooks;
        List<NotebookGroup> _notebookGroups;

        int _pageSize;

        public ProductController()
        {
            _pageSize = 3;
            SetupData();
        }

        public IActionResult Index(int? group, int pageNumber)
        {
            var notebooksFiltered = _notebooks.Where(d => !group.HasValue || d.NotebookGroupId == group.Value);

            // Put a list of groups in ViewData
            ViewData["Groups"] = _notebookGroups;
            // Get the id of the current group and put it in TempData
            ViewData["CurrentGroup"] = group ?? 0;

            return View(ListViewModel<Notebook>.GetModel(notebooksFiltered, pageNumber, _pageSize));
        }

        private void SetupData()
        {
            _notebookGroups = new List<NotebookGroup>
            {
                new NotebookGroup {NotebookGroupId = 1, GroupName = "Apple"},
                new NotebookGroup {NotebookGroupId = 2, GroupName = "ASUS"},
                new NotebookGroup {NotebookGroupId = 3, GroupName = "Lenovo"},
                new NotebookGroup {NotebookGroupId = 4, GroupName = "Xiaomi"},
                new NotebookGroup {NotebookGroupId = 5, GroupName = "HP"},
                new NotebookGroup {NotebookGroupId = 6, GroupName = "Dell"}
            };

            _notebooks = new List<Notebook>
            {
                new Notebook {NotebookId = 1, NotebookName = "Apple MacBook Pro", Description = "Normal notebook",
                    Price = 2000, NotebookGroupId = 1, Image = "MacBookPro.jpg" },
                new Notebook {NotebookId = 2, NotebookName = "ASUS ZenBook", Description = "The best notebook",
                    Price = 2500, NotebookGroupId = 2, Image = "ZenBook.jpg" },
                new Notebook {NotebookId = 3, NotebookName = "Lenovo ThinkPad", Description = "Good notebook for work",
                    Price = 1000, NotebookGroupId = 3, Image = "ThinkPad.jpg" },
                new Notebook { NotebookId = 4, NotebookName = "Lenovo IdeaPad", Description = "Good notebook for regular user",
                     Price = 700, NotebookGroupId = 3, Image = "IdeaPad.jpg" },
                new Notebook { NotebookId = 5, NotebookName = "Xiaomi RedmiBook Pro", Description = "Good notebook",
                     Price = 2500, NotebookGroupId = 4, Image = "RedmiBookPro.jpg" },
                new Notebook { NotebookId = 6, NotebookName = "Xiaomi Mi Notebook Pro", Description = "Fast notebook",
                     Price = 3000, NotebookGroupId = 4, Image = "MiNotebookPro.jpg" },
                new Notebook { NotebookId = 7, NotebookName = "HP Pavilion", Description = "Unknown notebook",
                     Price = 900, NotebookGroupId = 5, Image = "Pavilion.jpg" }
            };
        }
    }
}
