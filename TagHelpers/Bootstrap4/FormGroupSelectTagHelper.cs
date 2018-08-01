using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace socialarts.club.TagHelpers.Bootstrap4
{
    public class FormGroupSelectTagHelper : FormGroupTagHelperBase {

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "form-group");

            if(!string.IsNullOrWhiteSpace(Label)) {
                output.Content.AppendHtml($"<label for='{Id}'>{Label}</label>");
            }

            // distinct
            output.Content.AppendHtml($"<select class='form-control' id='{Id}'>");

            var childContent = await output.GetChildContentAsync();
            var innerHtml = childContent.GetContent();
            output.Content.AppendHtml(innerHtml);

            output.Content.AppendHtml($"</select>");
        }
    }
}