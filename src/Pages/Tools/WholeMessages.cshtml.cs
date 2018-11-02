using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using socialarts.club.Data;

namespace socialarts.club.Pages.Tools
{
    public class WholeMessagesModel : ToolsPageModel<WholeMessages>
    {
        public override string CitationAuthor => "McKay";

        public override int CitationYear => 2009;

        public WholeMessagesModel(
            ApplicationDbContext db,
            UserManager<IdentityUser> userManager) : base(db, userManager)
        {
        }
    }
}
