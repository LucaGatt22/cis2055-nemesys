using NEMESYS.Models.Contexts;
using NEMESYS.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using NEMESYS.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace NEMESYS.Models.Repositories
{
    public class ReportRepository : IReportRepository
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
                return _appDbContext.Reports.Include(b => b.CampusCategory).Include(b => b.Status).OrderBy(b => b.CreatedDate);
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
                return _appDbContext.Reports.Include(b => b.CampusCategory).Include(b => b.Status).FirstOrDefault(p => p.Id == reportId);
            }
            catch (Exception ex)
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
                    existingReport.CampusCategoryId = report.CampusCategoryId;

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


        public IEnumerable<ICategory> GetAllCampusCategories()
        {
            try
            {
                //Not loading related report posts
                return _appDbContext.CampusCategories;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public ICategory GetCampusCategoryById(int categoryId)
        {
            try
            {
                //Not loading related report posts
                return _appDbContext.CampusCategories.FirstOrDefault(c => c.Id == categoryId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }
        public IEnumerable<ICategory> GetAllStatuses()
        {
            try
            {
                //Not loading related report posts
                return _appDbContext.Statuses;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public ICategory GetStatusById(int statusId)
        {
            try
            {
                //Not loading related report posts
                return _appDbContext.Statuses.FirstOrDefault(c => c.Id == statusId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public IList<ReporterInfo> GetReporterFrequencies()
        {
            var reporterFrequencies = _appDbContext.Reports
                .GroupBy(r => r.UserId)
                .Select(g => new ReporterInfo
                {
                    Name = g.First().User.Email, // Assuming Author is navigable from Report
                    ReportCount = g.Count()
                })
                .OrderByDescending(r => r.ReportCount)
                .Take(3)
                .ToList();
            if (reporterFrequencies != null) {
                return reporterFrequencies;
            } else
            {
                return null;
            } 
        }

        /*IList<ReporterInfo> IReportRepository.GetReporterFrequencies()
        {
            var reporterFrequencies = _appDbContext.Reports
            .GroupBy(r => r.UserId)
            .Select(g => new ReporterInfo
            {
                Name = g.First().User.Email, // Assuming Author is navigable from Report
                ReportCount = g.Count()
            })
            .OrderByDescending(r => r.ReportCount)
            .Take(3)
            .ToList();
        }*/
    }
}
