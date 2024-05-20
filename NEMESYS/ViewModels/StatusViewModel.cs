using NEMESYS.Models;

namespace NEMESYS.ViewModels
{
    public class StatusViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Report> Reports { get; set; }


       
    }
}
