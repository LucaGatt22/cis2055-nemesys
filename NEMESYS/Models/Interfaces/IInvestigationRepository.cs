namespace NEMESYS.Models.Interfaces
{
    public interface IInvestigationRepository
    {
        IEnumerable<Investigation> GetAllInvestigations();
        Investigation GetInvestigationById(int investigationId);
        void CreateInvestigation(Investigation investigation);
        void UpdateInvestigation(Investigation investigation);


    }
}
