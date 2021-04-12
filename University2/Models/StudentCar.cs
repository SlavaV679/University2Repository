namespace University.Models
{
    public class StudentCar
    {
        public StudentCar(Student student, Car car)
        {
            Student = student;
            Car = car;
        }

        public Student Student { get; set; }

        public Car Car { get; set; }
    }
}

