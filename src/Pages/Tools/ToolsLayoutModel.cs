using Microsoft.AspNetCore.Mvc.RazorPages;
using socialarts.club.Data;

namespace socialarts.club.Pages.Tools
{
    public abstract class ToolsLayoutModel : PageModel
    {
        public bool Disabled { get; set; }

        public abstract string CitationAuthor { get; }

        public abstract int CitationYear { get; }
    }
}
