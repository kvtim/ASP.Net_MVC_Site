using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_953504_Kozlovski.Entities
{
    public class NotebookGroup
    {
        public int NotebookGroupId { get; set; }
        public string GroupName { get; set; }

        public List<Notebook> Dishes { get; set; }
    }
}
