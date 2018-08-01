using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace socialarts.club.TagHelpers.Bootstrap4
{
    public class FormGroupInputTagHelper : FormGroupTagHelperBase {

        public string Type { get; set; }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "form-group");

            if(!string.IsNullOrWhiteSpace(Label)) {
                output.Content.AppendHtml($"<label for='{Id}'>{Label}</label>");
            }

            // distinct
            output.Content.AppendHtml($"<input type='{Type}' class='form-control' id='{Id}' placeholder='{Placeholder}'/>");

            return Task.CompletedTask;
        }
    }
}