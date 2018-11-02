using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using socialarts.club.Data;

namespace socialarts.club.Pages.Tools
{
    public class CostBenefitAnalysisModel : ToolsPageModel<CostBenefitAnalysis>
    {
        public override string CitationAuthor => "Bilsker";

        public override string CitationYear => "2009";

        public CostBenefitAnalysisModel(
            ApplicationDbContext db,
            UserManager<IdentityUser> userManager) : base(db, userManager)
        {
        }
    }
}
