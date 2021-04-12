namespace University.Models
{
    public class UniverStudent
    {
        public UniverStudent(Student student, Univer univer)
        {
            Student = student;
            Univer = univer;
        }

        public Student Student { get; set; }

        public Univer Univer { get; set; }
    }
}