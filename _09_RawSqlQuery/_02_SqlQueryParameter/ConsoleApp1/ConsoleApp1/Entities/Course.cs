namespace ConsoleApp1.Entities
{
    public class Course : Entity
    {
        public string? CourseName { get; set; }
        public decimal Price { get; set; }
        public int HoursToComplete { get; set; }
        public ICollection<Section> Sections { get; set; } = new List<Section>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
