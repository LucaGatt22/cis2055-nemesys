using NEMESYS.Models.Interfaces;

namespace NEMESYS.Models
{
    public class CampusCategory : ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Collection navigation property
        public List<Report> Reports { get; set; }


        public List<Investigation> Investigations { get; set; }
    }
}
