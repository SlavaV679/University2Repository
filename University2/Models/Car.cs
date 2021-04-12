namespace University.Models
{
    public class Car
    {
        public Car(int studentId, string name, double price)
        {
            StudentId = studentId;
            Name = name;
            Price = price;
        }

        public int StudentId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}