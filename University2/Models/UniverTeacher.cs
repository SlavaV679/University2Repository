namespace University.Models
{
    public class UniverTeacher
    {
            public Teacher Teacher { get; set; }

            public Univer Univer { get; set; }

            public UniverTeacher(Teacher teacher, Univer univer)
            {
                Teacher = teacher;
                Univer = univer;
            }
        }
}