using NEMESYS.ViewModels;

namespace NEMESYS.Models.Interfaces
{
    public interface IReportRepository
    {
        IEnumerable<Report> GetAllReports();
        Report GetReportById(int reportId);
        void CreateReport(Report report);
        void UpdateReport(Report report);

        IEnumerable<ICategory> GetAllCampusCategories();
        ICategory GetCampusCategoryById(int categoryId);

        IEnumerable<ICategory> GetAllStatuses();
        ICategory GetStatusById(int statusId);
        IList<ReporterInfo> GetReporterFrequencies();
    }
}
