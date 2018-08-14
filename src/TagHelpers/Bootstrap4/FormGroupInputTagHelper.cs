using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace socialarts.club.TagHelpers.Bootstrap4
{
    public class FormGroupInputTagHelper : FormGroupTagHelperBase {

        public string Type { get; set; }

        internal override Task<string> BuildFormControl(TagHelperContext context, TagHelperOutput output)
        {
            var result = $"<input class='form-control' id='{Id}' placeholder='{Placeholder}' type='{Type}' />";

            return Task.FromResult(result);
        }
    }
}