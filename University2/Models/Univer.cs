namespace University.Models
{
    public class Univer : ModelBase
    {
        public Univer (int id, string name, string fullName)
        {
            Id = id;
            Name = name;
            FullName = fullName;
        }

        public string FullName { get; set; }

        public int StudentsCount { get; set; }

        public int TeachersCount { get; set; }
    }
}