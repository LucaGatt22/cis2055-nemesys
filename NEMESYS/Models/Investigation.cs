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

        //Foreign Key - navigation property
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int ReportId { get; set; }
        public Report Report { get; set; }

    }
}
