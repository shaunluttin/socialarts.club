using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace socialarts.club.TagHelpers.Bootstrap4
{
    public abstract class FormGroupTagHelperBase : TagHelper {

        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Placeholder { get; set; }

        public string Label { get; set; }
    }
}