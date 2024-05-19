using NEMESYS.Models.Interfaces;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace NEMESYS.Models.Repositories
{
    public class MockReportRepository : IReportRepository
    {
        private List<Report>? _reports;
        private List<Category>? _categories;

        public MockReportRepository() { 
            if (_reports == null)
            {
                InitializeReports();
            }
            if (_categories == null)
            {
                InitializeCategories();
            }

        }


        private void InitializeReports()
        {
            _reports = new List<Report>()
            {
                new Report()
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "AGA Today",
                    Content = "Today's AGA is characterized by a series of discussions and debates around ...",
                    CreatedDate = DateTime.UtcNow,
                    ImageUrl = "/images/seed1.jpg"
                },
                new Report()
                {
                    Id = 2,
                    CategoryId = 2,
                    Title = "Traffic is incredible",
                    Content = "Today's traffic can't be described using words. Only an image can do that ...",
                    CreatedDate = DateTime.UtcNow.AddDays(-1),
                    ImageUrl = "/images/seed2.jpg"
                },
                new Report()
                {
                    Id = 3,
                    CategoryId = 2,
                    Title = "When is Spring really starting?",
                    Content = "Clouds clouds all around us. I thought spring started already, but ...",
                    CreatedDate = DateTime.UtcNow.AddDays(-2),
                    ImageUrl = "/images/seed3.jpg"
                }
            };

        }

        private void InitializeCategories()
        {
            _categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Comedy"
                },
                new Category()
                {
                    Id = 2,
                    Name = "News"
                }
            };
        }

        public IEnumerable<Report> GetAllReports()
        {
            //This is inefficient - but sufficient for a Mock repository
            List<Report> result = new List<Report>();
            foreach (var post in _reports)
            {
                post.Category = _categories.FirstOrDefault(c => c.Id == post.CategoryId);
                result.Add(post);
            }
            return result;
        }

        public Report GetReportById(int reportId)
        {
            var report = _reports.FirstOrDefault(p => p.Id == reportId); //if not found, it returns null
            var category = _categories.FirstOrDefault(c => c.Id == report.CategoryId);
            report.Category = category;
            return report;
        }

        public void CreateReport(Report report)
        {
            report.Id = _reports.Count + 1;
            _reports.Add(report);
        }

        public void UpdateReport(Report report)
        {
            var existingReport = _reports.FirstOrDefault(p => p.Id == report.Id);
            if (existingReport != null)
            {
                //No need to update CreatedDate (id of course won't be changed)
                existingReport.ImageUrl = report.ImageUrl;
                existingReport.Title = report.Title;
                existingReport.Content = report.Content;
                existingReport.UpdatedDate = report.UpdatedDate;
                existingReport.CategoryId = report.CategoryId;
            }
        }


        public IEnumerable<Category> GetAllCategories()
        {
            return _categories;
        }
        public Category GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(c => c.Id == categoryId);

            //Adding all Reports associated with this category
            category.Reports = _reports.Where(p => p.CategoryId == categoryId).ToList();
            return category;
        }

    }
}
