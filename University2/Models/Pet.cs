namespace University.Models
{
    public class Pet : ModelBase
    {
        public Pet(int id, string name, string category, double weight, int studentId)
        {
            Id = id;
            Name = name;
            Category = category;
            Weight = weight;
            StudentId = studentId;
        }

        public string Category { get; set; }

        public double Weight { get; set; }

        public int StudentId { get; set; }
    }
}