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
    // TODO Rename these with the suffix *PageModel, maybe.
    public class AssertivenessScorecardModel : ToolsPageModel<AssertivenessScorecard>
    {
        public override string CitationAuthor => "Paterson";

        public override string CitationYear => "2000";

        public List<SelectListItem> AssessmentOptions { get; set; }
            = new List<SelectListItem>
            {
                new SelectListItem("Assertive", "assertive"),
                new SelectListItem("Passive", "passive"),
                new SelectListItem("Aggressive", "aggressive"),
                new SelectListItem("Passive/Aggressive", "p/a"),
            };

        public AssertivenessScorecardModel(
            ApplicationDbContext db,
            UserManager<IdentityUser> userManager) : base(db, userManager)
        {
        }

    }
}
