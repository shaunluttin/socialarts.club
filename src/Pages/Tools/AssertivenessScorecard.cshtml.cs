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
    public class AssertivenessScorecardModel : PageModel
    {
        private readonly ApplicationDbContext db;

        [BindProperty]
        public AssertivenessScorecard Form { get; set; }

        public List<SelectListItem> AssessmentOptions { get; set; }
            = new List<SelectListItem>
            {
                new SelectListItem("Assertive", "assertive"),
                new SelectListItem("Passive", "passive"),
                new SelectListItem("Aggressive", "aggressive"),
                new SelectListItem("Passive/Aggressive", "p/a"),
            };

        public bool Disabled { get; set; }

        public AssertivenessScorecardModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task OnGetAsync(int id = 0)
        {
            if (id <= 0) return;

            var doc = await db.ToolsDocument.FindAsync(id);
            Form = JsonConvert.DeserializeObject<AssertivenessScorecard>(doc.Json);
            Disabled = true;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var doc = new ToolsDocument
            {
                Name = nameof(AssertivenessScorecardModel),
                Json = JsonConvert.SerializeObject(Form),
            };

            // TODO (security): Add the current user as the document's owner.
            var result = db.ToolsDocument.Add(doc);
            await db.SaveChangesAsync();

            // Post/Redirect/Get to avoid multiple form submission
            return RedirectToPage(HttpContext.Request.Path, new { doc.Id });
        }
    }
}
