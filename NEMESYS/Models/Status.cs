using NEMESYS.Models.Interfaces;

namespace NEMESYS.Models
{
    public class Status : ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Collection navigation property
        public List<Report> Reports { get; set; }


        
    }
}
