using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using socialarts.club.ViewComponents.Extensions;

namespace socialarts.club.Pages.Tools
{
    [BindProperties]
    public class AssertivenessScorecardModel : PageModel
    {
        public DateTime Date { get ; set; }

        public async Task<IActionResult> OnPostAsync() 
        {
            Date.Dump();

            await Task.CompletedTask;

            // Post/Redirect/Get to avoid multiple form submission
            return RedirectToPage(HttpContext.Request.Path);
        }
    }
}
