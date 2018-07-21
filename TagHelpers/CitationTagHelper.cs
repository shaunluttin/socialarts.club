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

            output.Content.AppendHtml($"<a href='{ReferencesPath}/{Author}-{Year}'><cite title='{title}'>{title}</cite></a> ({Author}, {Year}).");
        }
    }
}