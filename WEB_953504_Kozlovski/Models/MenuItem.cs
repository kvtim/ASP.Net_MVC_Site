using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_953504_Kozlovski.Models
{
    public class MenuItem
    {
        // whether it is a page or a controller method
        public bool IsPage { get; set; } = false;

        // area name
        public string Area { get; set; } = "";

        // controller action name
        public string Action { get; set; } = "";

        // controller name
        public string Controller { get; set; } = "";

        // page name
        public string Page { get; set; } = "";

        // the CSS class for the current menu item
        public string Active { get; set; } = "";

        // lettering text
        public string Text { get; set; } = "";
    }
}
