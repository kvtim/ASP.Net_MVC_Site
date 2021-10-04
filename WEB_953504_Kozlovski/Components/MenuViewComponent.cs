using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953504_Kozlovski.Models;

namespace WEB_953504_Kozlovski.Components
{
    public class MenuViewComponent : ViewComponent
    {
        // Инициализация списка элементов меню
        private List<MenuItem> _menuItems = new List<MenuItem>
        {
            new MenuItem{ Controller = "Home", Action = "Index", Text = "Lab 2" },
            new MenuItem{ Controller = "Product", Action = "Index", Text = "Каталог" },
            new MenuItem{ IsPage = true, Area = "Admin", Page = "/Index", Text = "Администрирование" }
        };

        public IViewComponentResult Invoke()
        {
            //Получение значений сегментов маршрута
            var controller = ViewContext.RouteData.Values["controller"];
            var page = ViewContext.RouteData.Values["page"];
            var area = ViewContext.RouteData.Values["area"];

            foreach (var item in _menuItems)
            {
                // Название контроллера совпадает?
                var _matchController = controller?.Equals(item.Controller) ?? false;

                // Название зоны совпадает?
                var _matchArea = area?.Equals(item.Area) ?? false;

                // Если есть совпадение, то сделать элемент меню активным
                // (применить соответствующий класс CSS)
                if (_matchController || _matchArea)
                {
                    item.Active = "active";
                }
            }
            return View(_menuItems);
        }
    }
}
