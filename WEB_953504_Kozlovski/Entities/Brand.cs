using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_953504_Kozlovski.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public List<Notebook> Notebooks { get; set; }
    }
}
