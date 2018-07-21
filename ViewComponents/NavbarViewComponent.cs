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

namespace socialarts.club.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private readonly List<string> ExcludedItems = new List<string> {
            "Index", 
            "Error",
            "Privacy",
        };

        private readonly IActionDescriptorCollectionProvider _provider;

        public NavbarViewComponent(IActionDescriptorCollectionProvider provider)
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
                .SelectMany(g => g);

            var defaultAreaActionsToUse = defaultAreaActions
                .Where(a => {
                    var title = a.AttributeRouteInfo.Template.Split("/").Last();
                    return !ExcludedItems.Contains(title);
                });

            var nestingGroups = defaultAreaActionsToUse
                .GroupBy(a => a.AttributeRouteInfo.Template.Split("/").Count());

            var rootItems = nestingGroups
                .Where(g => g.Key == 1)
                .SelectMany(g => g)
                .Select(a => new NavbarItemViewModel
                {
                    Title = a.AttributeRouteInfo.Template,
                    Url = a.ViewEnginePath,
                });

            var dropDownItems = nestingGroups
                .Where(g => g.Key == 2)
                .SelectMany(g => g)
                .GroupBy(a => a.AttributeRouteInfo.Template.Split("/").First())
                .ToDictionary(
                    g => g.Key, 
                    g => g.Select(a => new NavbarItemViewModel { 
                        Title = a.AttributeRouteInfo.Template.Split("/").Last(),
                        Url = a.ViewEnginePath
                    })
                );

            var model = new NavbarViewComponentModel
            {
                RootNavbarItems = rootItems,
                DropDownNavbarItems = dropDownItems
            };

            return View(model);
        }
    }
}