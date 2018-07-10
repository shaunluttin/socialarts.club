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
        private readonly RazorProjectFileSystem _razorFileSystem;
        private readonly RazorPagesOptions _pagesOptions;

        public NavbarViewComponent(
            RazorProjectFileSystem razorFileSystem,
            IOptions<RazorPagesOptions> pagesOptionsAccessor)
        {
            _razorFileSystem = razorFileSystem;
            _pagesOptions = pagesOptionsAccessor.Value;
        }

        private const string Directive = @"@page";

        // See: Mvc\src\Microsoft.AspNetCore.Mvc.RazorPages\Internal\RazorProjectPageRouteModelProvider.cs
        // See: Razor\src\Microsoft.AspNetCore.Mvc.Razor.Extensions\PageDirective.cs
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var navbarItems = await _razorFileSystem
                .EnumerateItems(_pagesOptions.RootDirectory)
                .WhereAsync(async item => await IsPage(item)) 
                .Select(item => new NavbarItemViewModel
                    {
                        Url = item.FilePathWithoutExtension,
                        Title = item.FileName
                    });

            var model = new NavbarViewComponentModel
            {
                NavbarItems = navbarItems
            };

            return View(model);
        }

        public async Task<bool> IsPage(RazorProjectItem item)
        {
            string line;

            // TODO (Shaun) Should we use Span<T> and .NET Core Pipes?
            var file = new StreamReader(item.PhysicalPath);
            while ((line = await file.ReadLineAsync()) != null)
            {
                var trimmed = line.Trim();

                if (trimmed == Directive)
                {
                    return true;
                }
            }

            return false;
        }
    }
}