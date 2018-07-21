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
        private readonly IActionDescriptorCollectionProvider _provider;

        public NavbarViewComponent(IActionDescriptorCollectionProvider provider)
        {
            _provider = provider;
        }

        public IViewComponentResult Invoke()
        {
            // TODO: Delete this developer debug code.
            foreach (PageActionDescriptor item in _provider.ActionDescriptors.Items)
            {
                if (item.AreaName == null)
                {
                    System.Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(item, Newtonsoft.Json.Formatting.Indented));
                }
            }

            var navbarItems = _provider.ActionDescriptors.Items
                .Where(item => item is PageActionDescriptor)
                .Cast<PageActionDescriptor>()
                .Where(item => item.AreaName == null)
                .Select(item =>
                {
                    var parts = item.ViewEnginePath.Split("/");
                    return new NavbarItemViewModel
                    {
                        Url = item.ViewEnginePath,

                        // TODO: Make this a drop down list when there are multiple parts.
                        Title = string.Join(" > ", parts)
                    };
                });

            var model = new NavbarViewComponentModel
            {
                NavbarItems = navbarItems
            };

            return View(model);
        }
    }
}