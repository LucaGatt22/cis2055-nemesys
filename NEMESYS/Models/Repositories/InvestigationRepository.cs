using NEMESYS.Models.Contexts;
using NEMESYS.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NEMESYS.Models.Repositories
{
    public class InvestigationRepository: IInvestigationRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly ILogger<InvestigationRepository> _logger;

        public InvestigationRepository(AppDbContext appDbContext, ILogger<InvestigationRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;  
        }


        public IEnumerable<Investigation> GetAllInvestigations()
        {
            try
            {
                //Using Eager loading with Include
                return _appDbContext.Investigations.Include(b => b.Category).OrderBy(b => b.CreatedDate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public Investigation GetInvestigationById(int investigationId)
        {
            try
            {
                //Using Eager loading with Include
                var x = _appDbContext.Investigations.Where(bp => bp.Id == 20).FirstOrDefault().Content;
                return _appDbContext.Investigations.Include(b => b.Category).FirstOrDefault(p => p.Id == investigationId);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }

        }

        public void CreateInvestigation(Investigation investigation)
        {
            try
            {
                _appDbContext.Investigations.Add(investigation);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public void UpdateInvestigation(Investigation investigation)
        {
            try
            {
                var existingInvestigation = _appDbContext.Investigations.SingleOrDefault(bp => bp.Id == investigation.Id);
                if (existingInvestigation != null)
                {
                    existingInvestigation.Title = investigation.Title;
                    existingInvestigation.Content = investigation.Content;
                    existingInvestigation.UpdatedDate = investigation.UpdatedDate;
                    existingInvestigation.ImageUrl = investigation.ImageUrl;
                    existingInvestigation.CategoryId = investigation.CategoryId;

                    _appDbContext.Entry(existingInvestigation).State = EntityState.Modified;
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
                //Not loading related investigation posts
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
                //Not loading related ivestigation posts
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
