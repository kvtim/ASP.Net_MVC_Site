using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WEB_953504_Kozlovski.Blazor.Client.Models
{
    public class DetailsViewModel
    {
        [JsonPropertyName("notebookName")]
        public string NotebookName { get; set; } // notebook name
        [JsonPropertyName("description")]
        public string Description { get; set; } // notebook descrption
        [JsonPropertyName("price")]
        public int Price { get; set; } // notebook price
        [JsonPropertyName("image")]
        public string Image { get; set; } // notebook image
    }
}
