using Microsoft.AspNetCore.Identity;
using NEMESYS.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace NEMESYS.Models
{
    public class Investigation
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime  UpdatedDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }

        //Foreign Key - navigation property (name + Id as the property name)
        public int ReportInvestigationId { get; set; }
        //Reference navigation property
        public ReportInvestigation ReportInvestigation { get; set; }
        
        //Foreign Key - navigation property
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
