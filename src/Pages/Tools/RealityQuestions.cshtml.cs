using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using socialarts.club.Data;

namespace socialarts.club.Pages.Tools
{
    public class RealityQuestionsModel : ToolsPageModel<RealityQuestions>
    {
        public override string CitationAuthor => "Bilsker";

        public override int CitationYear => 2009;

        public RealityQuestionsModel(
            ApplicationDbContext db, 
            UserManager<IdentityUser> userManager) : base(db, userManager)
        {
        }
    }
}
