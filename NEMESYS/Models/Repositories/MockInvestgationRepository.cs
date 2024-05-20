using NEMESYS.Models.Interfaces;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace NEMESYS.Models.Repositories
{
    public class MockInvestigationRepository : IInvestigationRepository
    {
        private List<Investigation>? _investigations;
        private List<CampusCategory>? _categories;

        public MockInvestigationRepository()
        {
            if (_investigations == null)
            {
                InitializeInvestigations();
            }
            if (_categories == null)
            {
                InitializeCategories();
            }

        }


        private void InitializeInvestigations()
        {
            _investigations = new List<Investigation>()
            {
                new Investigation()
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "AGA Today",
                    Content = "Today's AGA is characterized by a series of discussions and debates around ...",
                    CreatedDate = DateTime.UtcNow,
                    ImageUrl = "/images/seed1.jpg"
                },
                new Investigation()
                {
                    Id = 2,
                    CategoryId = 2,
                    Title = "Traffic is incredible",
                    Content = "Today's traffic can't be described using words. Only an image can do that ...",
                    CreatedDate = DateTime.UtcNow.AddDays(-1),
                    ImageUrl = "/images/seed2.jpg"
                },
                new Investigation()
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
            _categories = new List<CampusCategory>()
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

        public IEnumerable<Investigation> GetAllInvestigations()
        {
            //This is inefficient - but sufficient for a Mock repository
            List<Investigation> result = new List<Investigation>();
            foreach (var post in _investigations)
            {
                post.Category = _categories.FirstOrDefault(c => c.Id == post.CategoryId);
                result.Add(post);
            }
            return result;
        }

        public Investigation GetInvestigationById(int investigationId)
        {
            var investigation = _investigations.FirstOrDefault(p => p.Id == investigationId); //if not found, it returns null
            var category = _categories.FirstOrDefault(c => c.Id == investigation.CategoryId);
            investigation.Category = category;
            return investigation;
        }

        public void CreateInvestigation(Investigation investigation)
        {
            investigation.Id = _investigations.Count + 1;
            _investigations.Add(investigation);
        }

        public void UpdateInvestigation(Investigation investigation)
        {
            var existingInvestigation = _investigations.FirstOrDefault(p => p.Id == investigation.Id);
            if (existingInvestigation != null)
            {
                //No need to update CreatedDate (id of course won't be changed)
                existingInvestigation.ImageUrl = investigation.ImageUrl;
                existingInvestigation.Title = investigation.Title;
                existingInvestigation.Content = investigation.Content;
                existingInvestigation.UpdatedDate = investigation.UpdatedDate;
                existingInvestigation.CategoryId = investigation.CategoryId;
            }
        }


        public IEnumerable<ICategory> GetAllCategories()
        {
            return _categories;
        }
        public ICategory GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(c => c.Id == categoryId);

            //Adding all Investigations associated with this category
            category.Investigations = _investigations.Where(p => p.CategoryId == categoryId).ToList();
            return category;
        }

    }
}