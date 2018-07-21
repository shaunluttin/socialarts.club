using System.Collections.Generic;
using System.Linq;

namespace socialarts.club.ViewComponents
{
    public class NavbarItemViewModel
    {
        // TODO (Shaun) Change type to Uri for safety.
        public string Url { get; set; }

        public string Title { get; set; }
    }

    public class NavbarViewComponentModel
    {
        public Dictionary<string, IEnumerable<NavbarItemViewModel>> DropDownNavbarItems 
            = new Dictionary<string, IEnumerable<NavbarItemViewModel>>();

        public IEnumerable<NavbarItemViewModel> RootNavbarItems =
            Enumerable.Empty<NavbarItemViewModel>();
    }
}