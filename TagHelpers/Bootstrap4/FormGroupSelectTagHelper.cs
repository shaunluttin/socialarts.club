using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace socialarts.club.TagHelpers.Bootstrap4
{
    public class FormGroupSelectTagHelper : FormGroupTagHelperBase {

        internal override async Task<string> BuildFormControl(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var innerHtml = childContent.GetContent();

            var result = new StringBuilder();
            result.Append($"<select class='form-control' id='{Id}'>");
            result.Append(innerHtml);
            result.Append($"</select>");
            
            return result.ToString();
        }
    }
}