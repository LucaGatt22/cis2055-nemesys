using NEMESYS.ViewModels;

namespace NEMESYS.ViewModels
{
    public class InvestigationListViewModel
    {
        public int TotalEntries { get; set; }
        public IEnumerable<InvestigationViewModel> Investigations { get; set; }
    }
}
