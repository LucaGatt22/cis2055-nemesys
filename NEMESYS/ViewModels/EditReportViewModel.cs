using System.ComponentModel.DataAnnotations;

namespace NEMESYS.ViewModels
{
    public class EditReportViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A title is required")]
        [StringLength(50)]
        [Display(Name = "Report heading")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Report content is required")]
        [StringLength(1500, ErrorMessage = "Report cannot be longer than 1500 characters")]
        public string Content { get; set; }

        //Nullable (will be ignored by the model binder and model state validation - non-nullable == required)
        public string? ImageUrl { get; set; }

        [Display(Name = "Featured Image")]
        public IFormFile? ImageToUpload { get; set; } //used only when submitting form

        [Display(Name = "Campus Category")]
        //Property used to bind user selection.
        [Required(ErrorMessage = "Campus Category is required")]
        public int CampusCategoryId { get; set; }

        //Property used solely to populate drop down
        public List<CategoryViewModel>? CampusCategoryList { get; set; }

    }
}
