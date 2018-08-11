using System.Collections.Generic;
using System.Linq;

namespace socialarts.club.ViewComponents
{
    public class RazorPageNavbarNavViewComponentModel
    {
        public Dictionary<string, IEnumerable<NavItemViewModel>> DropDownNavItems 
            = new Dictionary<string, IEnumerable<NavItemViewModel>>();

        public IEnumerable<NavItemViewModel> RootNavItems =
            Enumerable.Empty<NavItemViewModel>();
    }
}