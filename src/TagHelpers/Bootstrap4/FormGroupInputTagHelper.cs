using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using socialarts.club.ViewComponents.Extensions;

namespace socialarts.club.TagHelpers.Bootstrap4
{
    public class FormGroupInputTagHelper : InputTagHelper
    {
        public string Label { get; set; }

        public FormGroupInputTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";

            if (context.AllAttributes.ContainsName("asp-for"))
            {
                // the InputTagHelper requires the asp-for attribute.
                base.Process(context, output);
            }

            // TODO: persist existing classes; this might use MergeAttributes or AddClass.
            output.Attributes.Add("class", "form-control");

            if (!output.Attributes.ContainsName("id"))
            {
                output.Attributes.SetAttribute("id", Guid.NewGuid());
            };

            // pass thru attributes
            CopyHtmlAttribute(context, output, "autofocus");
            CopyHtmlAttribute(context, output, "placeholder");

            // open div
            output.PreElement.SetHtmlContent("<div class='form-group'>");

            if (!string.IsNullOrWhiteSpace(Label))
            {
                var id = output.Attributes["id"].Value;
                output.PreElement.AppendHtml($"<label for='{id}'>{Label}</label>");
            }

            // close div
            output.PostElement.SetHtmlContent("</div>");
        }

        private void CopyHtmlAttribute(TagHelperContext context, TagHelperOutput output, string attribute)
        {
            if (context.AllAttributes.ContainsName(attribute))
            {
                output.CopyHtmlAttribute(attribute, context);
            }
        }
    }
}