using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.Options;
using socialarts.club.ObjectExtensions;
using socialarts.club.IEnumerableExtensions;

namespace socialarts.club.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private const string PageDirective = "@page";

        // TODO (Shaun) Inject these excluded items.
        private readonly List<string> ExcludeList = new List<string> 
        {
            "Index",
            "Error", 
            "Privacy", 
        };

        private readonly RazorProjectFileSystem _razorFileSystem;

        private readonly RazorPagesOptions _pagesOptions;

        public NavbarViewComponent(
            RazorProjectFileSystem razorFileSystem,
            IOptions<RazorPagesOptions> pagesOptionsAccessor)
        {
            _razorFileSystem = razorFileSystem;
            _pagesOptions = pagesOptionsAccessor.Value;
        }

        // See: Mvc\src\Microsoft.AspNetCore.Mvc.RazorPages\Internal\RazorProjectPageRouteModelProvider.cs
        // See: Razor\src\Microsoft.AspNetCore.Mvc.Razor.Extensions\PageDirective.cs
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var navbarItems = await _razorFileSystem
                .EnumerateItems(_pagesOptions.RootDirectory)
                .WhereAsync(async item => await BelongsInNavbar(item)) 
                .Select(item => new NavbarItemViewModel
                    {
                        Url = item.FilePathWithoutExtension,
                        Title = item.FileName.Replace(item.Extension, "")
                    });

            var model = new NavbarViewComponentModel
            {
                NavbarItems = navbarItems
            };

            return View(model);
        }

        public async Task<bool> BelongsInNavbar(RazorProjectItem item) => 
            !OnExcludeList(item) && 
            await HasPageDirective(item);

        public bool OnExcludeList(RazorProjectItem item) =>
            ExcludeList.Any(x => x == item.FileName.Replace(item.Extension, ""));

        public async Task<bool> HasPageDirective(RazorProjectItem item) {
            string line;

            // TODO (Shaun) Consider using the Span<T> and Pipes API.
            var file = new StreamReader(item.PhysicalPath);
            while ((line = await file.ReadLineAsync()) != null)
            {
                var trimmed = line.Trim();

                if (trimmed == PageDirective)
                {
                    return true;
                }
            }

            return false;
        }
    }
}