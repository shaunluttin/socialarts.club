using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace socialarts.club.TagHelpers
{
    public class CitationTagHelper : TagHelper {

        public const string ReferencesPath = "/References";

        public string Author { get; set; }

        public string Year { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {

            var childContent = await output.GetChildContentAsync();
            var title = childContent.GetContent();

            var relativePath = $"{ReferencesPath}/{Author}-{Year}";

            var citeElement = $"<cite title='{title}'>{title}</cite>";
            var linkElement = $"<a href='{relativePath}'>{citeElement}</a>";
            var spanElement = $"<span>({Author}, {Year})</span>";
            var content = $"{linkElement} {spanElement}";

            output.Content.AppendHtml(content);
        }
    }
}