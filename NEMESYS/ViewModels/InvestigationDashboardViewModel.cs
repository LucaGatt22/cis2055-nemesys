using System.ComponentModel.DataAnnotations;

namespace NEMESYS.ViewModels
{
    public class InvestigationDashboardViewModel
    {
        [Display(Name = "Total Investigations")]
        public int TotalEntries { get; set; }
        [Display(Name = "Total Registered Users")]
        public int TotalRegisteredUsers { get; set; }
    }

}

