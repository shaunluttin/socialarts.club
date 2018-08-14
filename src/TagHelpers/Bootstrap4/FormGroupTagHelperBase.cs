using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace socialarts.club.TagHelpers.Bootstrap4
{
    public abstract class FormGroupTagHelperBase : TagHelper
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Placeholder { get; set; }

        public string Label { get; set; }

        public bool Autofocus { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "form-group");

            if (!string.IsNullOrWhiteSpace(Label))
            {
                output.Content.AppendHtml($"<label for='{Id}'>{Label}</label>");
            }

            var formControl = await BuildFormControl(context, output);
            if (Autofocus)
            {
                formControl = InsertAutofocusAttribute(formControl);
            }

            output.Content.AppendHtml(formControl);
        }

        private string InsertAutofocusAttribute(string formControl)
        {
            var index = formControl.IndexOf(' ');
            return formControl.Insert(index, " autofocus");
        }

        internal abstract Task<string> BuildFormControl(TagHelperContext context, TagHelperOutput output);
    }
}