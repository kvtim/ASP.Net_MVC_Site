using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953504_Kozlovski.Entities;

namespace WEB_953504_Kozlovski.Models
{
    /// <summary>
    /// Клас описывает одну позицию в корзине
    /// </summary>
    public class CartItem
    {
        public Notebook Notebook { get; set; }
        public int Quantity { get; set; }
    }
}
