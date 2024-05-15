using NEMESYS.Models.Contexts;
using NEMESYS.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NEMESYS.Models.Repositories
{
    public class ReportRepository: IReportRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly ILogger<ReportRepository> _logger;

        public ReportRepository(AppDbContext appDbContext, ILogger<ReportRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;  
        }


        public IEnumerable<Report> GetAllReports()
        {
            try
            {
                //Using Eager loading with Include
                return _appDbContext.Reports.Include(b => b.Category).OrderBy(b => b.CreatedDate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public Report GetReportById(int reportId)
        {
            try
            {
                //Using Eager loading with Include
                var x = _appDbContext.Reports.Where(bp => bp.Id == 20).FirstOrDefault().Content;
                return _appDbContext.Reports.Include(b => b.Category).FirstOrDefault(p => p.Id == reportId);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }

        }

        public void CreateReport(Report report)
        {
            try
            {
                _appDbContext.Reports.Add(report);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public void UpdateReport(Report report)
        {
            try
            {
                var existingReport = _appDbContext.Reports.SingleOrDefault(bp => bp.Id == report.Id);
                if (existingReport != null)
                {
                    existingReport.Title = report.Title;
                    existingReport.Content = report.Content;
                    existingReport.UpdatedDate = report.UpdatedDate;
                    existingReport.ImageUrl = report.ImageUrl;
                    existingReport.CategoryId = report.CategoryId;

                    _appDbContext.Entry(existingReport).State = EntityState.Modified;
                    _appDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }


        public IEnumerable<Category> GetAllCategories()
        {
            try
            {
                //Not loading related report posts
                return _appDbContext.Categories;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            try
            {
                //Not loading related report posts
                return _appDbContext.Categories.FirstOrDefault(c => c.Id == categoryId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

    }
}
