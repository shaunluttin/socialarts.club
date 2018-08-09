using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace socialarts.club.TagHelpers.Bootstrap4
{
    public class FormGroupTextareaTagHelper : FormGroupTagHelperBase {

        internal override Task<string> BuildFormControl(TagHelperContext context, TagHelperOutput output)
        {
            var result = new StringBuilder();
            result.Append($"<textarea class='form-control' id='{Id}' placeholder='{Placeholder}'>");
            result.Append($"</textarea>");

            return Task.FromResult(result.ToString());
        }
    }
}