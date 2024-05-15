namespace NEMESYS.Models.Interfaces
{
    public interface IReportRepository
    {
        IEnumerable<Report> GetAllReports();
        Report GetReportById(int reportId);
        void CreateReport(Report report);
        void UpdateReport(Report report);

        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);

    }
}
