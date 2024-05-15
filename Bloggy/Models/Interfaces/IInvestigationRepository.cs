namespace Bloggy.Models.Interfaces
{
    public interface IInvestigationRepository
    {
        IEnumerable<Investigation> GetAllInvestigations();
        Investigation GetInvestigationById(int investigationId);
        void CreateInvestigation(Investigation investigation);
        void UpdateInvestigation(Investigation investigation);

        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);

    }
}
