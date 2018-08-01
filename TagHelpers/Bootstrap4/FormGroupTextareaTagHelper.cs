using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace socialarts.club.TagHelpers.Bootstrap4
{
    public class FormGroupTextareaTagHelper : FormGroupTagHelperBase {

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "form-group");

            if(!string.IsNullOrWhiteSpace(Label)) {
                // TODO consider reusing this conditional label logic
                output.Content.AppendHtml($"<label for='{Id}'>{Label}</label>");
            }

            // distinct
            output.Content.AppendHtml($"<textarea class='form-control' id='{Id}' placeholder='{Placeholder}'>");
            output.Content.AppendHtml($"</textarea>");

            return Task.CompletedTask;
        }
    }
}