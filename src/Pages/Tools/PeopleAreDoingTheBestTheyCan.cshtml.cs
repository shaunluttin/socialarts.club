using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using socialarts.club.Data;

namespace socialarts.club.Pages.Tools
{
    public class PeopleAreDoingTheBestTheyCanModel : ToolsPageModel<PeopleAreDoingTheBestTheyCan>
    {
        public override string CitationAuthor => "McKay";

        public override string CitationYear => "2000";

        public PeopleAreDoingTheBestTheyCanModel(
            ApplicationDbContext db,
            UserManager<IdentityUser> userManager) : base(db, userManager)
        {
        }
    }
}
