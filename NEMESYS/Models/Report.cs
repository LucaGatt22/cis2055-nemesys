﻿using Microsoft.AspNetCore.Identity;
using NEMESYS.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace NEMESYS.Models
{
    public class Report
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime  UpdatedDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }

        //Foreign Key - navigation property (name + Id as the property name)
        public int CampusCategoryId { get; set; }
        //Reference navigation property
        public CampusCategory CampusCategory { get; set; } 

        //Foreign Key - navigation property
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }


        public List<Investigation> GetAssociatedInvestigations { get; }

        public Status Status { get; set; }

    }
}
