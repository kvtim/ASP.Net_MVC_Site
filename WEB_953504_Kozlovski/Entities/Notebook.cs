using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_953504_Kozlovski.Entities
{
    public class Notebook
    {
        public int NotebookId { get; set; } // notebook id
        public string NotebookName { get; set; } // notebook name
        public string Description { get; set; } // notebook description
        public int Price { get; set; } // notebook price
        public string Image { get; set; } // image file name
 
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
