using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace socialarts.club.TagHelpers.Bootstrap4
{
    public abstract class FormGroupTagHelperBase : TagHelper {

        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Placeholder { get; set; }

        public string Label { get; set; }
    }

    public class FormGroupInputTagHelper : FormGroupTagHelperBase {

        public string Type { get; set; }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "form-group");
            output.Content.AppendHtml($"<label for='{Id}'>{Label}</label>");

            // distinct
            output.Content.AppendHtml($"<input type='{Type}' class='form-control' id='{Id}' placeholder='{Placeholder}'/>");

            return Task.CompletedTask;
        }
    }

    public class FormGroupTextareaTagHelper : FormGroupTagHelperBase {

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "form-group");
            output.Content.AppendHtml($"<label for='{Id}'>{Label}</label>");

            // distinct
            output.Content.AppendHtml($"<textarea class='form-control' id='{Id}' placeholder='{Placeholder}'>");
            output.Content.AppendHtml($"</textarea>");

            return Task.CompletedTask;
        }
    }

    public class FormGroupSelectTagHelper : FormGroupTagHelperBase {

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "form-group");
            output.Content.AppendHtml($"<label for='{Id}'>{Label}</label>");

            // distinct
            output.Content.AppendHtml($"<select class='form-control' id='{Id}'>");

            var childContent = await output.GetChildContentAsync();
            var innerHtml = childContent.GetContent();
            output.Content.AppendHtml(innerHtml);

            output.Content.AppendHtml($"</select>");
        }
    }
}