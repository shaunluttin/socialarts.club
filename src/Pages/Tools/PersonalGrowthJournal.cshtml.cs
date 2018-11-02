using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using socialarts.club.Data;

namespace socialarts.club.Pages.Tools
{
    public class PersonalGrowthJournalModel : ToolsPageModel<PersionalGrowthJournal>
    {
        public override string CitationAuthor => "Alberti";

        public override int CitationYear => 1995;

        public PersonalGrowthJournalModel(
            ApplicationDbContext db,
            UserManager<IdentityUser> userManager) : base(db, userManager)
        {
        }
    }
}
