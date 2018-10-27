using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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

        private readonly UserManager<IdentityUser> userManager;

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

        public AssertivenessScorecardModel(
            ApplicationDbContext db,
            UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task OnGetAsync(int id = 0)
        {
            if (id <= 0) return;

            var currentUserId = userManager.GetUserId(User);

            var doc = await db.ToolsDocument.FindAsync(id);

            if (doc == null)
            {
                // return 404 not found (or other appropriate status).
            }
            else if (doc.OwnerId != currentUserId)
            {
                // return 403 forbidden (or other appropriate status).
            }

            Disabled = true;
            Form = JsonConvert.DeserializeObject<AssertivenessScorecard>(doc.Json);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var doc = await SaveToolsDocument();

            // Post/Redirect/Get to avoid multiple form submission
            return RedirectToPage(HttpContext.Request.Path, new { doc.Id });
        }

        public async Task<ToolsDocument> SaveToolsDocument()
        {
            var currentUserId = userManager.GetUserId(User);

            // ~/Tools/AssertivenessScorecard
            var razorPage = PageContext.ActionDescriptor.DisplayName;
            var name = razorPage.Split('/').Last();

            var doc = new ToolsDocument
            {
                Name = name,
                TemplateUrlPath = razorPage,
                OwnerId = currentUserId,
                Json = JsonConvert.SerializeObject(Form),
            };

            var result = db.ToolsDocument.Add(doc);
            await db.SaveChangesAsync();

            return doc;
        }
    }
}
