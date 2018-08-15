using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using socialarts.club.Data;
using socialarts.club.ViewComponents.Extensions;

namespace socialarts.club.Pages.Tools
{
    [BindProperties]
    public class AssertivenessScorecardModel : PageModel
    {
        private readonly ApplicationDbContext db;

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

        public AssertivenessScorecardModel(ApplicationDbContext db) {
            this.db = db;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dictionary = ModelState.ToDictionary(
                item => item.Key, 
                item => item.Value.RawValue.ToString());

            var json = JsonConvert.SerializeObject(dictionary);

            var doc = new ToolsDocument 
            {
                Name = nameof(AssertivenessScorecardModel), 
                Json = json,
            };

            // TODO (security): Add the current user as the document's owner.
            var result = db.ToolsDocument.Add(doc);
            await db.SaveChangesAsync();

            // Post/Redirect/Get to avoid multiple form submission
            return RedirectToPage(HttpContext.Request.Path, new { doc.Id });
        }
    }
}
