using System.Collections.Generic;

namespace socialarts.club.ViewComponents
{
    public class NavbarItemViewModel
    {
        // TODO (Shaun) Change type to Uri
        public string Url { get; set; }

        public string Title { get; set; }
    }

    public class NavbarViewComponentModel
    {
        public IEnumerable<NavbarItemViewModel> NavbarItems { get; set; }
            = new List<NavbarItemViewModel>();
    }
}