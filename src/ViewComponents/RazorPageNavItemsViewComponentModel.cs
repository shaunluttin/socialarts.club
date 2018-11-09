using System.Collections.Generic;
using System.Linq;

namespace socialarts.club.ViewComponents
{
    public class RazorPageNavItemsViewComponentModel
    {
        public Dictionary<string, IEnumerable<NavItemViewModel>> ChildNavItems 
            = new Dictionary<string, IEnumerable<NavItemViewModel>>();

        public IEnumerable<NavItemViewModel> RootNavItems =
            Enumerable.Empty<NavItemViewModel>();
    }
}