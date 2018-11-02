using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using socialarts.club.Data;

namespace socialarts.club.TagHelpers
{
    [HtmlTargetElement("citation", TagStructure = TagStructure.WithoutEndTag)]
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
            var entry = await dbContext.BibliographyEntry.SingleAsync(e => e.Slug == slug);

            System.Console.WriteLine("==================");
            System.Console.WriteLine("==================");
            System.Console.WriteLine(Author);
            System.Console.WriteLine(Year);
            System.Console.WriteLine(slug);
            System.Console.WriteLine(entry.Title);
            System.Console.WriteLine("==================");
            System.Console.WriteLine("==================");

            var relativePath = $"{ReferencesPath}/{entry.Slug}";

            // TODO Consider introducing a entry.ShortTitle for citation readability.
            var citeElement = $"<cite title='{entry.Title}'>{entry.Title}</cite>";
            var linkElement = $"<a href='{relativePath}'>{citeElement}</a>";
            var spanElement = $"<span>({Author}, {Year})</span>";
            var content = $"{linkElement} {spanElement}";

            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetHtmlContent(content);
        }
    }
}