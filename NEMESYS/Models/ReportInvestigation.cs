namespace NEMESYS.Models
{
    public class ReportInvestigation
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public Report Report { get; set; }

        public int InvestigationId { get; set; }
        public Investigation Investigation { get; set; }
    }
}
