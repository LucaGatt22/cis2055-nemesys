﻿using NEMESYS.Models;

namespace NEMESYS.ViewModels
{
    public class ReportViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int ReadCount { get; set; }
        public CampusCategoryViewModel CampusCategory { get; set; }
        public AuthorViewModel Author { get; set; }
        public StatusViewModel Status { get; set; }

    }
}
