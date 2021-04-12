namespace University.Models
{
    public class UniverStudentTeacher 
    {
        public UniverStudentTeacher(Univer univer, Teacher teacher)
        {
            Univer = univer;
            Teacher = teacher;
        }

        public UniverStudentTeacher(Univer univer, Student student)
        {
            Univer = univer;
            Student = student;
        }

        public UniverStudentTeacher(Univer univer, Teacher teacher, Student student)
        {
            Univer = univer;
            Teacher = teacher;
            Student = student;
        }

        public Univer Univer { get; set; }

        public Teacher Teacher { get; set; }

        public Student Student { get; set; }

    }
}