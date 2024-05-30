using NEMESYS.Models;

namespace NEMESYS.ViewModels
{
    public class HallOfFameViewModel
    {
        public IList<ReporterInfo> TopReporters { get; set; }
    }

    public class ReporterInfo
    {
        public string Name { get; set; }
        public int ReportCount { get; set; }
    }
}

