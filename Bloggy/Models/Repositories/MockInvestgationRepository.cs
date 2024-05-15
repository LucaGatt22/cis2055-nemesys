using Bloggy.Models.Interfaces;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Bloggy.Models.Repositories
{
    public class MockInvestigationRepository : IInvestigationRepository
    {
        private List<Investigation>? _investigations;
        private List<Category>? _categories;

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
            var existingBlogPost = _investigations.FirstOrDefault(p => p.Id == investigation.Id);
            if (existingBlogPost != null)
            {
                //No need to update CreatedDate (id of course won't be changed)
                existingBlogPost.ImageUrl = investigation.ImageUrl;
                existingBlogPost.Title = investigation.Title;
                existingBlogPost.Content = investigation.Content;
                existingBlogPost.UpdatedDate = investigation.UpdatedDate;
                existingBlogPost.CategoryId = investigation.CategoryId;
            }
        }


        public IEnumerable<Category> GetAllCategories()
        {
            return _categories;
        }
        public Category GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(c => c.Id == categoryId);

            //Adding all BlogPosts associated with this category
            category.Investigations = _investigations.Where(p => p.CategoryId == categoryId).ToList();
            return category;
        }

    }
}