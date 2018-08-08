using System.Collections.Generic;
using System.Linq;

namespace socialarts.club.ViewComponents
{
    public class NavbarViewComponentModel
    {
        public Dictionary<string, IEnumerable<NavbarItemViewModel>> DropDownNavbarItems 
            = new Dictionary<string, IEnumerable<NavbarItemViewModel>>();

        public IEnumerable<NavbarItemViewModel> RootNavbarItems =
            Enumerable.Empty<NavbarItemViewModel>();
    }
}