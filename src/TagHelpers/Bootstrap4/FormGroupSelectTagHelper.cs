using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace socialarts.club.TagHelpers.Bootstrap4
{
    public class FormGroupSelectTagHelper : SelectTagHelper
    {
        private readonly BootstrapTagHelperService bootstrap;

        public FormGroupSelectTagHelper(
            BootstrapTagHelperService bootstrap,
            IHtmlGenerator generator) : base(generator)
        {
            this.bootstrap = bootstrap;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";

            if (context.AllAttributes.ContainsName("asp-for"))
            {
                base.Process(context, output);
            }

            bootstrap.SurroundWithFormGroup(context, output);
        }
    }
}