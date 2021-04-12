namespace University.Models
{
    public class Student : Human
    {
        public Student(int id, string name, int age, int univerId)
        {
            Id = id;
            Name = name;
            Age = age;
            UniverId = univerId;
        }

        public int UniverId { get; set; }
    }
}
