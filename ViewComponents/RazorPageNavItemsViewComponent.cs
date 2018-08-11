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
using Microsoft.AspNetCore.Mvc.Infrastructure;
using socialarts.club.ViewComponents.Extensions;

namespace socialarts.club.ViewComponents
{
    // TODO Reconsider coupling the nabar to the file system.
    public class RazorPageNavItemsViewComponent : ViewComponent
    {
        private readonly List<string> ExcludedTitles = new List<string> {
            "", 
            "Index", 
            "Error",
            "Privacy",
        };

        private readonly IActionDescriptorCollectionProvider _provider;

        public RazorPageNavItemsViewComponent(IActionDescriptorCollectionProvider provider)
        {
            _provider = provider;
        }

        public IViewComponentResult Invoke()
        {
            var allActions = _provider.ActionDescriptors.Items;

            var pageActions = allActions
                .Where(a => a is PageActionDescriptor)
                .Cast<PageActionDescriptor>();

            var areaGroups = pageActions.GroupBy(a => a.AreaName);

            var defaultAreaActions = areaGroups
                .Where(g => g.Key == null)
                .SelectMany(g => g)
                .Dump();

            var defaultAreaActionsToUse = defaultAreaActions
                .Where(a => {
                    // TODO Factor out the splitting; 
                    // TODO Perhaps do the splitting only once for better perf.
                    var title = a.ViewEnginePath.Split("/").Skip(1).Last();
                    return !ExcludedTitles.Contains(title);
                });

            var nestingGroups = defaultAreaActionsToUse
                .GroupBy(a => a.ViewEnginePath.Split("/").Skip(1).Count());

            var rootItems = nestingGroups
                .Where(g => g.Key == 1)
                .SelectMany(g => g)
                .Select(a => new NavItemViewModel
                {
                    Title = a.ViewEnginePath.TrimStart('/'),
                    Path = a.ViewEnginePath,
                });

            var dropDownItems = nestingGroups
                .Where(g => g.Key == 2)
                .SelectMany(g => g)
                .GroupBy(a => a.ViewEnginePath.Split("/").Skip(1).First())
                .ToDictionary(
                    g => g.Key, 
                    g => g.Select(a => new NavItemViewModel 
                    { 
                        Title = a.ViewEnginePath.Split("/").Last(),
                        Path = a.ViewEnginePath
                    })
                );

            var model = new RazorPageNavItemsViewComponentModel
            {
                RootNavItems = rootItems,
                DropDownNavItems = dropDownItems
            };

            return View(model);
        }
    }
}