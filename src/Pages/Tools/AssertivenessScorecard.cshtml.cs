using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace socialarts.club.Pages.Tools
{
    public class AssertivenessScorecardModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync() 
        {
            await Task.CompletedTask;

            // Post/Redirect/Get to avoid multiple form submission
            return RedirectToPage(HttpContext.Request.Path);
        }
    }
}
