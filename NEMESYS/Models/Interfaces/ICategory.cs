namespace NEMESYS.Models.Interfaces
{
    public interface ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Collection navigation property
        public List<Report> Reports { get; set; }


        public List<Investigation> Investigations { get; set; }
    }
}
