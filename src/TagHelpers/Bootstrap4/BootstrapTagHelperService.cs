using System;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace socialarts.club.TagHelpers.Bootstrap4
{
    public class BootstrapTagHelperService
    {
        public void SurroundWithFormGroup(TagHelperContext context, TagHelperOutput output)
        {
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

            if (output.Attributes.TryGetAttribute("label", out var result))
            {
                var id = output.Attributes["id"].Value;
                var label = result.Value;
                output.PreElement.AppendHtml($"<label for='{id}'>{label}</label>");
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