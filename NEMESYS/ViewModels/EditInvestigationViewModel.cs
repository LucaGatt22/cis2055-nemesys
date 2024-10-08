﻿using System.ComponentModel.DataAnnotations;

namespace NEMESYS.ViewModels
{
    public class EditInvestigationViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A title is required")]
        [StringLength(50)]
        [Display(Name = "Investigation heading")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Investigation content is required")]
        [StringLength(1500, ErrorMessage = "Investigation cannot be longer than 1500 characters")]
        public string Content { get; set; }

        //Nullable (will be ignored by the model binder and model state validation - non-nullable == required)
        public string? ImageUrl { get; set; }

        [Display(Name = "Featured Image")]
        public IFormFile? ImageToUpload { get; set; } //used only when submitting form

        [Display(Name = "Report Status")]
        //Property used to bind user selection.
        [Required(ErrorMessage = "Report Status is required")]
        public int StatusId { get; set; } 

        //Property used solely to populate drop down
        public List<StatusViewModel>? StatusList { get; set; }
        public int ReportId { get; internal set; }
    }
}
