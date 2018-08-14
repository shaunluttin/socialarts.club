using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using socialarts.club.Data;

namespace socialarts.club.TagHelpers
{
    public class CitationTagHelper : TagHelper {

        private readonly ApplicationDbContext dbContext;

        public CitationTagHelper(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        public const string ReferencesPath = "/References";

        public string Author { get; set; }

        public string Year { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {

            var slug = $"{Author}-{Year}".ToLowerInvariant();
            var entry = dbContext.BibliographyEntry.Single(e => e.Slug == slug);

            var childContent = await output.GetChildContentAsync();
            var shortTitle = childContent.GetContent();

            var relativePath = $"{ReferencesPath}/{entry.Slug}";

            var citeElement = $"<cite title='{entry.Title}'>{shortTitle}</cite>";
            var linkElement = $"<a href='{relativePath}'>{citeElement}</a>";
            var spanElement = $"<span>({Author}, {Year})</span>";
            var content = $"{linkElement} {spanElement}";

            output.Content.AppendHtml(content);
        }
    }
}