using NEMESYS.Models.Interfaces;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace NEMESYS.Models.Repositories
{
    public class MockReportRepository : IReportRepository
    {
        private List<Report>? _reports;
        private List<CampusCategory>? _campusCategories;

        public MockReportRepository() { 
            if (_reports == null)
            {
                InitializeReports();
            }
            if (_campusCategories == null)
            {
                InitializeCampusCategories();
            }

        }


        private void InitializeReports()
        {
            _reports = new List<Report>()
            {
                new Report()
                {
                    Id = 1,
                    CampusCategoryId = 1,
                    Title = "AGA Today",
                    Content = "Today's AGA is characterized by a series of discussions and debates around ...",
                    CreatedDate = DateTime.UtcNow,
                    ImageUrl = "/images/seed1.jpg"
                },
                new Report()
                {
                    Id = 2,
                    CampusCategoryId = 2,
                    Title = "Traffic is incredible",
                    Content = "Today's traffic can't be described using words. Only an image can do that ...",
                    CreatedDate = DateTime.UtcNow.AddDays(-1),
                    ImageUrl = "/images/seed2.jpg"
                },
                new Report()
                {
                    Id = 3,
                    CampusCategoryId = 2,
                    Title = "When is Spring really starting?",
                    Content = "Clouds clouds all around us. I thought spring started already, but ...",
                    CreatedDate = DateTime.UtcNow.AddDays(-2),
                    ImageUrl = "/images/seed3.jpg"
                }
            };

        }

        private void InitializeCampusCategories()
        {
            _campusCategories = new List<CampusCategory>()
            {
                new CampusCategory()
                {
                    Id = 1,
                    Name = "Msida Campus"
                },
                new CampusCategory()
                {
                    Id = 2,
                    Name = "Valletta Campus"
                },
                new CampusCategory()
                {
                    Id = 3,
                    Name = "Marsaxlokk Campus"
                },
                new CampusCategory()
                {
                    Id = 3,
                    Name = "Gozo Campus"
                }
            };
        }

        public IEnumerable<Report> GetAllReports()
        {
            //This is inefficient - but sufficient for a Mock repository
            List<Report> result = new List<Report>();
            foreach (var report in _reports)
            {
                report.CampusCategory = _campusCategories.FirstOrDefault(c => c.Id == report.CampusCategoryId);
                result.Add(report);
            }
            return result;
        } 

        public Report GetReportById(int reportId)
        {
            var report = _reports.FirstOrDefault(p => p.Id == reportId); //if not found, it returns null
            var campusCategory = _campusCategories.FirstOrDefault(c => c.Id == report.CampusCategoryId);
            report.CampusCategory = campusCategory;
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
                existingReport.CampusCategoryId = report.CampusCategoryId;
            }
        }


        public IEnumerable<ICategory> GetAllCampusCategories()
        {
            return _campusCategories;
        }
        public ICategory GetCampusCategoryById(int categoryId)
        {
            var campusCategory = _campusCategories.FirstOrDefault(c => c.Id == categoryId);

            //Adding all Reports associated with this campusCategory
            campusCategory.Reports = _reports.Where(p => p.CampusCategoryId == categoryId).ToList();
            return campusCategory;
        } 

    }
}
