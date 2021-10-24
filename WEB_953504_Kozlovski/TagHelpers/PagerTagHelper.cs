using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_953504_Kozlovski.TagHelpers
{
    public class PagerTagHelper : TagHelper
    {
        LinkGenerator _linkGenerator;
        // current page number
        public int PageCurrent { get; set; }
        // total number of pages
        public int PageTotal { get; set; }
        // additional css pager class
        public string PagerClass { get; set; }
        // action name
        public string Action { get; set; }
        // controller name
        public string Controller { get; set; }
        public int? BrandId { get; set; }

        public PagerTagHelper(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // pager markup container
            output.TagName = "nav";
            // pager
            var ulTag = new TagBuilder("ul");

            ulTag.AddCssClass("pagination");
            ulTag.AddCssClass(PagerClass);

            for (int i = 1; i <= PageTotal; i++)
            {
                var url = _linkGenerator.GetPathByAction(Action, Controller,
                    new  { pageNo = i, group = BrandId == 0 ? null : BrandId });

                // getting the layout of one pager button
                var item = GetPagerItem(url: url, text: i.ToString(), active: i == PageCurrent,
                    disabled: i == PageCurrent);

                // add a button to the pager layout
                ulTag.InnerHtml.AppendHtml(item);
            }
            // add pager to container
            output.Content.AppendHtml(ulTag);
        }
        /// <summary>
        /// Generates the layout of one pager button
        /// </summary>
        /// <param name="url">address</param>
        /// <param name="text">pager button text</param>
        /// <param name="active">sign of the current page</param>
        /// <param name="disabled">deny access to the button</param>
        /// <returns>object of class TagBuilder</returns>
        private TagBuilder GetPagerItem(string url, string text, bool active = false, bool disabled = false)
        {
            // create tag <li>
            var liTag = new TagBuilder("li");

            liTag.AddCssClass("page-item");
            liTag.AddCssClass(active ? "active" : "");

            //liTag.AddCssClass(disabled ? "disabled" : "");
            // create tag <a>
            var aTag = new TagBuilder("a");

            aTag.AddCssClass("page-link");
            aTag.Attributes.Add("href", url);
            aTag.InnerHtml.Append(text);

            // add <a> tag inside <li>
            liTag.InnerHtml.AppendHtml(aTag);
            return liTag;
        }
    }
}