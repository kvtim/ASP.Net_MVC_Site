using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WEB_953504_Kozlovski.Blazor.Client.Models
{
    public class ListViewModel
    {
        [JsonPropertyName("notebookId")]
        public int NotebookId { get; set; } // notebook id

        [JsonPropertyName("notebookName")]
        public string NotebookName { get; set; } // notebook name
    }
}
