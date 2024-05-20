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

    }
}
