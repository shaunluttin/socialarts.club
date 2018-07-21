
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace socialarts.club.TagHelpers.Bootstrap4
{
    public class FormGroupTagHelper : TagHelper {

        // TODO Introduce an input type enum.
        public string Type { get; set; }

        public string Id { get; set; }

        public string Placeholder { get; set; }

        public string Label { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "form-group");

            output.Content.AppendHtml($"<label for='{Id}'>{Label}</label>");
            output.Content.AppendHtml($"<input type='{Type}' class='form-control' id='{Id}' placeholder='{Placeholder}'>");

            await Task.Delay(0);
        }
    }
}