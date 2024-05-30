using System.ComponentModel.DataAnnotations;

namespace NEMESYS.ViewModels
{
    public class InvestigationViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "A title is required")]
        [StringLength(50)]
        [Display(Name = "Investigation heading")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Investigation content is required")]
        [StringLength(1500, ErrorMessage = "Investigation cannot be longer than 1500 characters")]
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int ReadCount { get; set; }
        public ReportViewModel Report { get; set; }
        public AuthorViewModel Author { get; set; }



    }
}
