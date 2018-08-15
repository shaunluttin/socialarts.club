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
        private readonly BootstrapTagHelperService bootstrap;

        public FormGroupInputTagHelper(
            BootstrapTagHelperService bootstrap,
            IHtmlGenerator generator) : base(generator)
        {
            this.bootstrap = bootstrap;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";

            if (context.AllAttributes.ContainsName("asp-for"))
            {
                base.Process(context, output);
            }

            bootstrap.SurroundWithFormGroup(context, output);
        }
    }
}