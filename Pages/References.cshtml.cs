using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using socialarts.club.Data;

namespace socialarts.club.Pages
{
    public class ReferencesModel : PageModel
    {
        public List<BibliographyEntry> Entries { get; set; }

        public ReferencesModel(ApplicationDbContext context)
        {
            Entries = context.BibliographyEntry.ToList();
        }
    }
}
