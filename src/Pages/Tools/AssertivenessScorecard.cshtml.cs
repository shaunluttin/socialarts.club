using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using socialarts.club.ViewComponents.Extensions;

namespace socialarts.club.Pages.Tools
{
    [BindProperties]
    public class AssertivenessScorecardModel : PageModel
    {
        public string Date { get; set; }

        public string Time { get; set; }

        public string Place { get; set; }

        public string PersonOrSituation { get; set; }

        public string YourResponse { get; set; }

        public string YourAssessment { get; set; }

        public List<SelectListItem> AssessmentOptions { get; set; }
            = new List<SelectListItem>
            {
                new SelectListItem("Assertive", "assertive"),
                new SelectListItem("Passive", "passive"),
                new SelectListItem("Aggressive", "aggressive"),
                new SelectListItem("Passive/Aggressive", "p/a"),
            };

        public string Outcome { get; set; }

        public string FeelingsAfter { get; set; }

        public string AlternativeResponse { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            await Task.CompletedTask;
            HttpContext.Request.Form.Dump();

            // Post/Redirect/Get to avoid multiple form submission
            return RedirectToPage(HttpContext.Request.Path);
        }
    }
}
