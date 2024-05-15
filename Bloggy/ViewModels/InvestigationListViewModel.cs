using Bloggy.ViewModels;

namespace Bloggy.ViewModels
{
    public class InvestigationListViewModel
    {
        public int TotalEntries { get; set; }
        public IEnumerable<InvestigationViewModel> Investigations { get; set; }
    }
}
